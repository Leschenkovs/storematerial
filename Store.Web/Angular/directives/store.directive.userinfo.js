// userInfo directive

(function () {
    "use strict";

    // userInfo directive
    var userinfoDirective = function () {
        return {
            restrict: 'EA',
            replace: false,
            templateUrl: 'Angular/partials/userinfo.html',
            controller: function ($scope, $rootScope, $state) {
                var off = $rootScope.$on('$stateChangeSuccess', function () {
                    var user = $rootScope.globals.currentUser;
                    if (user)
                        $scope.forUser = (user.role == 'admin' ? { width: '16.66666666666667%' } : { width: '20%' });
                });
                $scope.$on('$destroy', off);
            }
        };
    };

    // register your directive into a dependent module.
    angular
        .module('store.WebUI.Directives')
        .directive("userInfo", [userinfoDirective]);
})();