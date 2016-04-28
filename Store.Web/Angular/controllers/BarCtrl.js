(function () {
    "use strict";

    // controller class definintion
    var BarCtrl = function ($scope, $state, $timeout, MaterialInStoreService) {

        var materialInStore = [];

        MaterialInStoreService.getMaterialInStores().then(function (value) {
            materialInStore = angular.copy(value);
        });


        $scope.options = { scaleShowVerticalLines: false };
        $scope.labels = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
        $scope.series = ['Series A', 'Series B'];
        $scope.data = [
          [65, 59, 80, 81, 56, 55, 40],
          [28, 48, 40, 19, 86, 27, 90]
        ];
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
    .controller("BarCtrl", ["$scope", "$state", "$timeout", "MaterialInStoreService", BarCtrl]);

})();