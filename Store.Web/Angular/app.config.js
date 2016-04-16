(function () {
    "use strict";

    angular
        .module("store.WebUI")
        .config(["$stateProvider", "$urlRouterProvider", "$locationProvider", function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $stateProvider.state("Index", {
                url: "/",
                templateUrl: "/Angular/views/index.html",
                controller: "IndexController"
            });

            $urlRouterProvider.otherwise("/");
        }]);

})();