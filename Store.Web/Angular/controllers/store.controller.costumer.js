(function () {
    "use strict";

    var CostumerController = function ($scope, $state, CostumerService, phoneFilter) {

        CostumerService.getAllCostumers().then(function (value) {
            $scope.costumers = value;
        });

        $scope.costumer =
        {
            id:"",
            name: "",
            address: "",
            telephone: "",
            description: ""
        };

        $scope.save = function (costumer, createCostumer) {
            if (createCostumer.$valid) {
                if (costumer.id != null && costumer.id != 'undefined' && costumer.id != "") {
                    CostumerService.updateCostumer(costumer).then(function (value) {
                        if (value) {
                            $scope.costumer =
                            {
                                id: "",
                                name: "",
                                address: "",
                                telephone: "",
                                description: ""
                            };
                        } else {
                            alert("Ошибка обновления записи!");
                        };
                    });
                } else {
                    CostumerService.addCostumer(costumer).then(function (value) {
                        if (value) {
                            $scope.costumers.push({
                                'id': value.id,
                                'name': value.name,
                                'address': value.address,
                                'telephone': value.telephone,
                                'description': value.description
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
            }
        };

        $scope.updateCostumer = function (index) {
            $scope.costumer = $scope.costumers[index];
        };

        $scope.deleteCostumer = function (index) {
            var id = $scope.costumers[index].id;
            CostumerService.deleteCostumer(id).then(function (value) {
                if (value) {
                    $scope.costumers.splice(index, 1);
                } else {
                    alert("Ошибка удаления записи!");
                };
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("CostumerController", ["$scope", "$state", "CostumerService", "phoneFilter", CostumerController]);
})();