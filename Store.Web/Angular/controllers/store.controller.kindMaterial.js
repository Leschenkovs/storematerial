(function () {
    "use strict";

    var KindMaterialController = function ($scope, $state, $filter, KindMaterialService, UnitMaterialService, UnitService, ngTableParams) {

        var originalData = [];

        $scope.kindMaterial =
        {
            id: "",
            articul: "",
            name: "",
            units: []
        };
        $scope.unitMaterial =
        {
            id: "",
            unitId: "",
            kindMaterialId: ""
        };

        ///////////// Work with checkbox
        //https://long2know.com/2015/07/angular-multiselect-dropdown/

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

        $scope.addUnit = function () {
            var unit = _.find($scope.units, function (rw) { return rw.id === $scope.unitId; });
            $scope.kindMaterial.units = $scope.kindMaterial.units.push(unit);
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

        $scope.saveUnitMaterial = function (unitMaterial, unitMaterialForm) {
            if (unitMaterialForm.$valid) {
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
            function (errorObject) {
                alert(errorObject.ExceptionMessage);
            });
        };

        $scope.saveKindMaterial = function (kindMaterial, kindMaterialForm) {
            if (kindMaterialForm.$valid) {
                KindMaterialService.addKindMaterial(kindMaterial).then(function (value) {
                    if (value) {
                        $scope.tableParams.settings().dataset.unshift(value);
                        $scope.tableParams.reload().then(function (data) {
                            if (data.length === 0 && self.tableParams.total() > 0) {
                                self.tableParams.page(self.tableParams.page() - 1);
                                self.tableParams.reload();
                            }
                        });
                        $scope.kindMaterial = null;
                    } else {
                        alert("Ошибка добавления записи!");
                    };
                });
            }
        };

        $scope.delete = function (id) {
            KindMaterialService.deleteKindMaterial(id).then(function (value) {
                if (value) {
                    _.remove($scope.tableParams.settings().dataset, function (item) {
                        return id === item.id;
                    });
                    $scope.tableParams.reload().then(function (data) {
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