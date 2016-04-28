(function () {
    "use strict";

    angular.module("store.WebUI.Services", []);
    angular.module("store.WebUI.Directives", []);
    angular.module("store.WebUI.Controllers", []);
    //angular.module("store.WebUI.Filters", []);
    //angular.module("store.WebUI.Factories", []);
    //angular.module("store.WebUI.Helpers", []);
    angular.module("store.WebUI.Externals", ["chart.js", "ui", "long2know", "ngSanitize", "ui.router", "ngTable", "ngCookies", 'ui.bootstrap']);

    var app = angular.module("store.WebUI", ["store.WebUI.Externals", "store.WebUI.Controllers", "store.WebUI.Directives", "store.WebUI.Services"]);
    app.value('userinfo', { fio: 'a12345654321x' });
    app.run(['$rootScope', '$location', '$cookieStore', '$http',
        function($rootScope, $location, $cookieStore, $http) {
            // keep user logged in after page refresh
            $rootScope.globals = $cookieStore.get('globals') || {};
            if ($rootScope.globals.currentUser) {
                $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
            }

            $rootScope.$on('$locationChangeStart', function(event, next, current) {
                // redirect to login page if not logged in
                if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                    $location.path('/login');
                }
            });

            //$rootScope.writeRole = $rootScope.globals.currentUser.role === 'admin' || $rootScope.globals.currentUser.role === 'read_write';
        }
    ]);

    app.config(function(ChartJsProvider) {
        // Configure all charts
        ChartJsProvider.setOptions({
            colours: ['#97BBCD', '#DCDCDC', '#F7464A', '#46BFBD', '#FDB45C', '#949FB1', '#4D5360'],
            responsive: true
        });
        // Configure all doughnut charts
        ChartJsProvider.setOptions('Doughnut', {
            animateScale: true,
            percentageInnerCutout: 20,
        });
    });

})();