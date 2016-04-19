(function() {
    "use strict";

    var SupplyController = function ($scope, $state, SupplyService) {

        $scope.supply =
        {
            id: "",
            unitId: "",
            kindMaterialId: ""
        };

        SupplyService.getAllSupplies().then(function (value) {
            $scope.supplies = value;
        });

        $scope.save = function (unitMaterial, createUnitMaterial) {
            if (createUnitMaterial.$valid) {
                UnitMaterialService.addUnitMaterial(unitMaterial).then(function (value) {
                    if (value) {
                        $scope.unitMaterials.push({
                            'id': value.id,
                            'shortNameUnit': value.shortNameUnit
                        });
                        $scope.unitMaterial =
                        {
                            id: "",
                            unitId: "",
                            kindMaterialId: ""
                        };
                    } else {
                        alert("Ошибка добавления записи!");
                    };
                });
            }
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("SupplyController", ["$scope", "$state", "SupplyService", SupplyController]);
})();