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

        $scope.update = function(row, rowForm) {
            ProviderService.updateProvider(row).then(function(value) {
                var originalRow = resetRow(row, rowForm);
                angular.extend(originalRow, row);
            });
        };


        $scope.save = function(provider, createProvider) {
            if (createProvider.$valid) {
                ProviderService.addProvider(provider).then(function(value) {
                    if (value) {
                        $scope.tableParams.settings().dataset.unshift({
                            'id': value.id,
                            'name': value.name,
                            'address': value.address,
                            'telephone': value.telephone,
                            'description': value.description
                        });
                        $scope.tableParams.reload().then(function(data) {
                            if (data.length === 0 && self.tableParams.total() > 0) {
                                self.tableParams.page(self.tableParams.page() - 1);
                                self.tableParams.reload();
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
                        alert("Ошибка добавления записи!");
                    };
                });
            }
        };

        $scope.delete = function(id) {
            ProviderService.deleteProvider(id).then(function(value) {
                if (value) {
                    _.remove($scope.tableParams.settings().dataset, function(item) {
                        return id === item.id;
                    });
                    $scope.tableParams.reload().then(function(data) {
                        if (data.length === 0 && self.tableParams.total() > 0) {
                            self.tableParams.page(self.tableParams.page() - 1);
                            self.tableParams.reload();
                        }
                    });
                }
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("ProviderController", ["$scope", "$state", "$filter", "ProviderService", "ngTableParams", ProviderController]);
})();