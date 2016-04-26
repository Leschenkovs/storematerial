(function () {
    "use strict";

    var CostumerController = function ($scope, $state, $filter, CostumerService, ngTableParams) {

        var originalData = [];

        CostumerService.getAllCostumers().then(function (value) {
            $scope.costumers = value;

            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
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

        $scope.update = function (row, rowForm) {
            CostumerService.updateCostumer(row).then(function (value) {
                var originalRow = resetRow(row, rowForm);
                angular.extend(originalRow, row);
            });
        };

        $scope.save = function(costumer, createCostumer) {
            if (createCostumer.$valid) {
                CostumerService.addCostumer(costumer).then(function(value) {
                    if (value) {
                        $scope.tableParams.settings().dataset.unshift({
                            'id': value.id,
                            'name': value.name,
                            'address': value.address,
                            'telephone': value.telephone,
                            'description': value.description
                        });
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
                        alert("Ошибка добавления записи!");
                    };
                });
            }
        };

        
        $scope.delete = function (id) {
            CostumerService.deleteCostumer(id).then(function (value) {
                if (value) {
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
            });
        };

    };

    angular
        .module("store.WebUI.Controllers")
        .controller("CostumerController", ["$scope", "$state", "$filter", "CostumerService", "ngTableParams", CostumerController]);
})();