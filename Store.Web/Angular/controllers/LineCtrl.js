(function () {
    "use strict";

    // controller class definintion
    var LineCtrl = function ($scope, $state, $timeout) {

        $scope.labels = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
        $scope.series = ['Series A', 'Series B'];
        $scope.data = [
          [65, 59, 80, 81, 56, 55, 40],
          [28, 48, 40, 19, 86, 27, 90]
        ];
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

        $timeout(function () {
            $scope.labels = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
            $scope.data = [
              [28, 48, 40, 19, 86, 27, 90],
              [65, 59, 80, 81, 56, 55, 40]
            ];
            $scope.series = ['Series C', 'Series D'];
        }, 3000);
    };

    // register your controller into a dependent module 
    //angular
    //    .module("store.WebUI.Controllers", ["chart.js", function () {
    //    }])
    //    .controller("LineCtrl", ["$scope", "$state", "$timeout", LineCtrl]);

    angular
    .module("store.WebUI.Controllers")
    .controller("LineCtrl", ["$scope", "$state", "$timeout", LineCtrl]);
})();