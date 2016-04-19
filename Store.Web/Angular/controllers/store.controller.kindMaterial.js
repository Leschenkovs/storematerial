(function () {
    "use strict";

    var KindMaterialController = function ($scope, $state, KindMaterialService, UnitMaterialService, UnitService) {

        $scope.kindMaterial =
        {
            id: "",
            articul: "",
            name: ""
        };
        $scope.unitMaterial =
        {
            id: "",
            unitId: "",
            kindMaterialId: ""
        };

        // List Units
        UnitService.getAllUnits().then(function (value) {
            $scope.units = value;
        });

//////// For UnitMaterial
        $scope.getUnitMaterial = function (id) {
            UnitMaterialService.getByKindMaterialId(id).then(function (value) {
                $scope.unitMaterials = value;
            });
        };

        $scope.deleteUnitMaterial = function (index) {
            var id = $scope.unitMaterials[index].id;
            UnitMaterialService.deleteUnitMaterial(id).then(function (value) {
                if (value) {
                    $scope.unitMaterials.splice(index, 1);
                } else {
                    alert("Ошибка удаления записи!");
                };
            });
        };

        $scope.saveUnitMaterial = function(unitMaterial, createUnitMaterial) {
            if (createUnitMaterial.$valid) {
                UnitMaterialService.addUnitMaterial(unitMaterial).then(function(value) {
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
/////////////////////

        KindMaterialService.getAllKindMaterials().then(function (value) {
            $scope.kindMaterials = value;
        });

        $scope.save = function (kindMaterial, createKindMaterial) {
            if (createKindMaterial.$valid) {
                if (kindMaterial.id != null && kindMaterial.id != 'undefined' && kindMaterial.id != "") {
                    KindMaterialService.updateKindMaterial(kindMaterial).then(function (value) {
                        if (value) {
                            $scope.kindMaterial =
                            {
                                id: "",
                                articul: "",
                                name: ""
                            };
                        } else {
                            alert("Ошибка обновления записи!");
                        };
                    });
                } else {
                    KindMaterialService.addKindMaterial(kindMaterial).then(function (value) {
                        if (value) {
                            $scope.kindMaterials.push({
                                'id': value.id,
                                'articul': value.articul,
                                'name': value.name,
                                'units':""
                            });
                            $scope.kindMaterial =
                            {
                                id: "",
                                articul: "",
                                name: ""
                            };
                        } else {
                            alert("Ошибка добавления записи!");
                        };
                    });
                }
            }
        };

        $scope.updateKindMaterial = function (index) {
            $scope.kindMaterial = $scope.kindMaterials[index];
        };

        $scope.deleteKindMaterial = function (index) {
            var id = $scope.kindMaterials[index].id;
            KindMaterialService.deleteKindMaterial(id).then(function (value) {
                if (value) {
                    $scope.kindMaterials.splice(index, 1);
                } else {
                    alert("Ошибка удаления записи!");
                };
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("KindMaterialController", ["$scope", "$state", "KindMaterialService","UnitMaterialService", "UnitService", KindMaterialController]);
})();