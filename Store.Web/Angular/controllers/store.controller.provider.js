(function() {
    "use strict";

    var ProviderController = function($scope, $state, $filter, ProviderService, ngTableParams) {

        var originalData = [];

        ProviderService.getAllProviders().then(function(value) {
            $scope.providers = value;

            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

        $scope.provider =
        {
            id: "",
            name: "",
            address: "",
            telephone: "",
            description: ""
        };

        $scope.cancel = function(row, rowForm) {
            var originalRow = resetRow(row, rowForm);
            angular.extend(row, originalRow);
        };

        function resetRow(row, rowForm) {
            row.isEditing = false;
            rowForm.$setPristine();
            for (var i in originalData) {
                if (originalData[i].id === row.id) {
                    return originalData[i];
                }
            }
        };

        function removeRow(id) {
            for (var i in originalData) {
                if (originalData[i].id === id) {
                    return originalData.splice(i, 1);
                }
            }
        };

        $scope.update = function(row, rowForm) {
            ProviderService.updateProvider(row).then(function(value) {
                var originalRow = resetRow(row, rowForm);
                angular.extend(originalRow, row);
            },
            function (errorObject) {
                alert(errorObject.ExceptionMessage);
            });
        };


        $scope.save = function(provider, createProvider) {
            if (createProvider.$valid) {
                ProviderService.addProvider(provider).then(function(value) {
                    if (value) {
                        originalData.push(value);
                        $scope.tableParams.settings().dataset.unshift(value);
                        $scope.tableParams.reload().then(function(data) {
                            if (data.length === 0 && $scope.tableParams.total() > 0) {
                                $scope.tableParams.page($scope.tableParams.page() - 1);
                                $scope.tableParams.reload();
                            }
                        });
                        $scope.provider =
                        {
                            id: "",
                            name: "",
                            address: "",
                            telephone: "",
                            description: ""
                        };
                    } else {
                        bootbox.alert("ОШИБКА добавления записи!");
                    };
                },
                function (errorObject) {
                    bootbox.alert(errorObject.ExceptionMessage);
                });
            }
        };

        $scope.delete = function(id) {
            ProviderService.deleteProvider(id).then(function(value) {
                if (value) {
                    removeRow(id);
                    _.remove($scope.tableParams.settings().dataset, function(item) {
                        return id === item.id;
                    });
                    $scope.tableParams.reload().then(function(data) {
                        if (data.length === 0 && $scope.tableParams.total() > 0) {
                            $scope.tableParams.page($scope.tableParams.page() - 1);
                            $scope.tableParams.reload();
                        }
                    });
                }
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("ProviderController", ["$scope", "$state", "$filter", "ProviderService", "ngTableParams", ProviderController]);
})();