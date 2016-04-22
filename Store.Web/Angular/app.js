(function () {
    "use strict";

    angular.module("store.WebUI.Services", []);
    angular.module("store.WebUI.Directives", []);
    angular.module("store.WebUI.Controllers", []);
    //angular.module("store.WebUI.Filters", []);
    //angular.module("store.WebUI.Factories", []);
    //angular.module("store.WebUI.Helpers", []);
    angular.module("store.WebUI.Externals", ["ui.router", "ngTable", "ngCookies"]);

    var app = angular.module("store.WebUI", ["store.WebUI.Externals", "store.WebUI.Controllers", "store.WebUI.Directives", "store.WebUI.Services"]);

    app.run(['$rootScope', '$location', '$cookieStore', '$http',
        function ($rootScope, $location, $cookieStore, $http) {
            // keep user logged in after page refresh
            $rootScope.globals = $cookieStore.get('globals') || {};
            if ($rootScope.globals.currentUser) {
                $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
            } else {
                $location.path('/login');
            }

            $rootScope.$on('$locationChangeStart', function(event, next, current) {
                // redirect to login page if not logged in
                if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                    $location.path('/login');
                }
            });
        }
    ]);
})();