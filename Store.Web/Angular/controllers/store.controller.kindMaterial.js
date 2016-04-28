(function () {
    "use strict";

    ///////////// Work with checkbox
    //https://long2know.com/2015/07/angular-multiselect-dropdown/

    var KindMaterialController = function ($scope, $state, $filter, $rootScope, KindMaterialService, UnitMaterialService, UnitService, ngTableParams) {

        var originalData = [];
        var isWriteRole = $rootScope.writeRole;

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

        ///////// List Units
        UnitService.getAllUnits().then(function (value) {
            $scope.units = value;
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        //////// For UnitMaterial
        $scope.getUnitMaterial = function (id) {
            UnitMaterialService.getByKindMaterialId(id).then(function (value) {
                $scope.unitMaterials = value;
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
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
                    bootbox.alert("ОШИБКА удаления записи!");
                };
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
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
                        bootbox.alert("ОШИБКА добавления записи!");
                    };
                },
                function (errorObject) {
                    bootbox.alert(errorObject.ExceptionMessage);
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
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        $scope.cancelKindMaterial = function (row, rowForm) {
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

        $scope.updateKindMaterial = function (row, rowForm) {
            KindMaterialService.updateKindMaterial(row).then(function (response) {
                var originalRow = resetRow(row, rowForm);
                angular.extend(row, response);
                angular.extend(originalRow, response);
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });
        };

        function reloadTableParams() {
            $scope.tableParams.reload().then(function (data) {
                if (data.length === 0 && $scope.tableParams.total() > 0) {
                    $scope.tableParams.page($scope.tableParams.page() - 1);
                    $scope.tableParams.reload();
                }
            });
        }

        $scope.saveKindMaterial = function (kindMaterial, kindMaterialForm) {
            if (kindMaterialForm.$valid) {
                KindMaterialService.addKindMaterial(kindMaterial).then(function (value) {
                    if (value) {
                        $scope.tableParams.settings().dataset.unshift(value);
                        $scope.kindMaterial = null;
                        reloadTableParams();
                    } else {
                        bootbox.alert("ОШИБКА добавления записи!");
                    };
                },
                function (errorObject) {
                    bootbox.alert(errorObject.ExceptionMessage);
                });
            }
        };

        $scope.deleteKindMaterial = function (id) {
            KindMaterialService.deleteKindMaterial(id).then(function (value) {
                if (value) {
                    _.remove($scope.tableParams.settings().dataset, function (item) {
                        return id === item.id;
                    });
                    reloadTableParams();
                } else {
                    bootbox.alert("ОШИБКА удаления!");
                }
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("KindMaterialController", ["$scope", "$state", "$filter", "$rootScope", "KindMaterialService", "UnitMaterialService", "UnitService", "ngTableParams", KindMaterialController]);
})();