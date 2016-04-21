(function () {
    "use strict";

    var KindMaterialController = function ($scope, $state, $filter, KindMaterialService, UnitMaterialService, UnitService, ngTableParams) {

        var originalData = [];

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

///////// List Units
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

            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

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
            KindMaterialService.updateKindMaterial(row).then(function (response) {
                var originalRow = resetRow(row, rowForm);
                angular.extend(originalRow, row);
            },
            function(errorObject) {
                alert(errorObject.ExceptionMessage);
            });
        };

        $scope.save = function (kindMaterial, createKindMaterial) {
            if (createKindMaterial.$valid) {
                KindMaterialService.addKindMaterial(kindMaterial).then(function (value) {
                    if (value) {
                        $scope.tableParams.settings().dataset.unshift({
                            'id': value.id,
                            'articul': value.articul,
                            'name': value.name,
                            'units': ""
                        });
                        $scope.tableParams.reload().then(function (data) {
                            if (data.length === 0 && self.tableParams.total() > 0) {
                                self.tableParams.page(self.tableParams.page() - 1);
                                self.tableParams.reload();
                            }
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
        };

        $scope.delete = function (id) {
            KindMaterialService.deleteKindMaterial(id).then(function (value) {
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
                } else {
                    alert("Ошибка удаления!");
                }
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("KindMaterialController", ["$scope", "$state", "$filter", "KindMaterialService", "UnitMaterialService", "UnitService", "ngTableParams", KindMaterialController]);
})();