(function () {
    "use strict";

    // controller class definintion
    var LineCtrl = function ($scope, $state, $timeout, CostumerService) {

        $scope.dateNow = new Date();
        var resultArray = [];

        CostumerService.getCostumersInfoForChart().then(function(value) {
            resultArray = value;
            $scope.series = resultArray.map(function (a) { return a.costumerName; });
            $scope.data = resultArray.map(function (a) { return a.costs.map(function (b) { return b.fullCost; }); });
        });


        $scope.labels = ['янв', 'фев', 'мар', 'апр', 'май', 'июн', 'июл', 'авг', 'сен', 'окт', 'ноя', 'дек'];

        $scope.onClick = function (points, evt) {
            console.log(points, evt);
        };
        $scope.onHover = function (points) {
            if (points.length > 0) {
                console.log('Point', points[0].value);
            } else {
                console.log('No point');
            }
        };

        //$timeout(function () {
        //    $scope.labels = ['янв', 'фев', 'мар', 'апр', 'май', 'июн', 'июл', 'авг', 'сен', 'окт', 'ноя', 'дек'];
        //    //$scope.data = [
        //    //  [28, 48, 40, 19, 86, 27, 90],
        //    //  [65, 59, 80, 81, 56, 55, 40]
        //    //];
        //    //$scope.series = ['Series C', 'Series D'];
        //}, 3000);
    };

    // register your controller into a dependent module 
    //angular
    //    .module("store.WebUI.Controllers", ["chart.js", function () {
    //    }])
    //    .controller("LineCtrl", ["$scope", "$state", "$timeout", LineCtrl]);

    angular
    .module("store.WebUI.Controllers")
    .controller("LineCtrl", ["$scope", "$state", "$timeout", "CostumerService", LineCtrl]);
})();