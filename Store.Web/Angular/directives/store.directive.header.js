// Footer directive

(function() {
    "use strict";

    // header directive
    var headerDirective = function() {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: 'Angular/partials/header.html',
            controller: function($scope) {
                //$scope.somestyle = { width: '20%' };
                //$scope.forUser = function() {
                //    if ($root.globals.currentUser.role == 'admin') {
                //        return $scope.somestyle;
                //    }
                //};;
            }
        };
    };

    // register your directive into a dependent module.
    angular
        .module('store.WebUI.Directives')
        .directive("storeHeader", [headerDirective]);
})();