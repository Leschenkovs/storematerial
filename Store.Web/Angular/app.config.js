(function () {
    "use strict";

    angular
        .module("store.WebUI")
        .config(["$stateProvider", "$urlRouterProvider", "$locationProvider", function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $stateProvider.state("index", {
                url: "/",
                templateUrl: "/Angular/views/index.html",
                controller: "IndexController"
            });

            $stateProvider.state("user/index", {
                url: "/user/index",
                templateUrl: "/Angular/views/user/index.html",
                controller: "UserController"
            });

            $stateProvider.state("user/create", {
                url: "/user/create",
                templateUrl: "/Angular/views/user/create.html",
                controller: "UserController"
            });

            $stateProvider.state("supply/index", {
                url: "/supply/index",
                templateUrl: "/Angular/views/supply/index.html",
                controller: "SupplyController"
            });

            $stateProvider.state("provider/index", {
                url: "/provider/index",
                templateUrl: "/Angular/views/provider/index.html",
                controller: "ProviderController"
            });

            $urlRouterProvider.otherwise("/");
        }]);
})();