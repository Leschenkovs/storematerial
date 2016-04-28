(function () {
    "use strict";

    var CostumerController = function ($scope, $state, $filter, $rootScope, CostumerService, ngTableParams) {

        var originalData = [];
        var isWriteRole = $rootScope.writeRole;

        CostumerService.getAllCostumers().then(function (value) {
            $scope.costumers = value;

            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        $scope.costumer =
        {
            id:"",
            name: "",
            address: "",
            telephone: "",
            description: ""
        };

        $scope.cancel = function (row, rowForm) {
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
                    return originalData.splice(i,1);
                }
            }
        };

        $scope.update = function (row, rowForm) {
            CostumerService.updateCostumer(row).then(function (value) {
                var originalRow = resetRow(row, rowForm);
                angular.extend(originalRow, row);
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });
        };

        $scope.save = function(costumer, createCostumer) {
            if (createCostumer.$valid) {
                CostumerService.addCostumer(costumer).then(function(value) {
                    if (value) {
                        originalData.push(value);
                        $scope.tableParams.settings().dataset.unshift(value);
                        $scope.tableParams.reload().then(function(data) {
                            if (data.length === 0 && $scope.tableParams.total() > 0) {
                                $scope.tableParams.page($scope.tableParams.page() - 1);
                                $scope.tableParams.reload();
                            }
                        });
                        $scope.costumer =
                        {
                            id: "",
                            name: "",
                            address: "",
                            telephone: "",
                            description: ""
                        };
                    } else {
                        bootbox.alert("Ошибка добавления записи!");
                    };
                },
                function (errorObject) {
                    bootbox.alert(errorObject.ExceptionMessage);
                });
            }
        };

        
        $scope.delete = function (id) {
            CostumerService.deleteCostumer(id).then(function (value) {
                if (value) {
                    removeRow(id);
                    _.remove($scope.tableParams.settings().dataset, function (item) {
                        return id === item.id;
                    });
                    $scope.tableParams.reload().then(function (data) {
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
        .controller("CostumerController", ["$scope", "$state", "$filter", "$rootScope", "CostumerService", "ngTableParams", CostumerController]);
})();