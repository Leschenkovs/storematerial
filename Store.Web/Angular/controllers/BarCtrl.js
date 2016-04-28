(function () {
    "use strict";

    // controller class definintion
    var BarCtrl = function ($scope, $state, $timeout, KindMaterialService, UnitMaterialService, MaterialInStoreService) {

        $scope.dateNow = new Date();
        $scope.selectedUnitMaterialId = 0;
        var resultArray = [];

        KindMaterialService.getAllKindMaterials().then(function (value) {
            $scope.kindMaterials = value;
        });

        UnitMaterialService.getAllUnitMaterials().then(function (value) {
            $scope.unitMaterials = value;
        });

        $scope.getChart = function () {
            MaterialInStoreService.getSupplyAndExperseInfo($scope.selectedUnitMaterialId).then(function (value) {
                resultArray = value;
                $scope.data = [
                    resultArray.map(function (a) { return a.supply; }),
                    resultArray.map(function (a) { return a.experse; })
                ];
            });

        };

        $scope.options = { scaleShowVerticalLines: false };
        $scope.labels = ['янв', 'фев', 'мар', 'апр', 'май', 'июн', 'июл', 'авг', 'сен','окт','ноя','дек'];
        $scope.series = ['поставка', 'отгрузка'];

        $timeout(function () {
            $scope.options = { scaleShowVerticalLines: true };
        }, 3000);
    };

    // register your controller into a dependent module 
    //angular
    //    .module("store.WebUI.Controllers",["chart.js", function() {    
    //    }])
    //    .controller("BarCtrl", ["$scope", "$state", "$timeout", BarCtrl]);
    angular
    .module("store.WebUI.Controllers")
    .controller("BarCtrl", ["$scope", "$state", "$timeout", "KindMaterialService", "UnitMaterialService", "MaterialInStoreService", BarCtrl]);

})();