(function () {
    "use strict";

    // controller class definintion
    var BarCtrl = function ($scope, $state, $timeout, KindMaterialService, UnitMaterialService, MaterialInStoreService) {

        $scope.dateNow = new Date();
        $scope.selectedUnitMaterialId = 0;
        var resultArray = [];

        KindMaterialService.getAllKindMaterials().then(function (value) {
            $scope.kindMaterials = value;
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        UnitMaterialService.getAllUnitMaterials().then(function (value) {
            $scope.unitMaterials = value;
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        $scope.getChart = function () {
            MaterialInStoreService.getSupplyAndExperseInfo($scope.selectedUnitMaterialId).then(function (value) {
                resultArray = value;
                $scope.data = [
                    resultArray.map(function (a) { return a.supply; }),
                    resultArray.map(function (a) { return a.experse; })
                ];
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });

        };

        $scope.options = { scaleShowVerticalLines: false };
        $scope.labels = ['янв', 'фев', 'мар', 'апр', 'май', 'июн', 'июл', 'авг', 'сен','окт','ноя','дек'];
        $scope.series = ['поставка', 'отгрузка'];

        $timeout(function () {
            $scope.options = { scaleShowVerticalLines: true };
        }, 3000);
    };

    angular
    .module("store.WebUI.Controllers")
    .controller("BarCtrl", ["$scope", "$state", "$timeout", "KindMaterialService", "UnitMaterialService", "MaterialInStoreService", BarCtrl]);

})();