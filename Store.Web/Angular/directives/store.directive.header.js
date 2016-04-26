(function() {
    "use strict";

    // header directive
    var headerDirective = function() {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: 'Angular/partials/header.html',
            controller: function ($scope, $rootScope, $state) {
                var off = $rootScope.$on('$stateChangeSuccess', function () {
                    var user = $rootScope.globals.currentUser;
                    $scope.forUser = (user.role == 'admin' ? { width: '16.66666666666667%' } : { width: '20%' });
                });
                $scope.$on('$destroy', off);
            }
        };
    };

    // register your directive into a dependent module.
    angular
        .module('store.WebUI.Directives')
        .directive("storeHeader", [headerDirective]);
})();