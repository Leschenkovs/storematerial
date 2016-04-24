(function () {
    "use strict";

    angular
        .module("store.WebUI")
        .config(["$stateProvider", "$urlRouterProvider", "$locationProvider", function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $stateProvider.state("login", {
                url: "/login",
                templateUrl: "/Angular/views/authentication/login.html",
                controller: "AuthenticationController"
            });

            $stateProvider.state("index", {
                url: "/",
                templateUrl: "/Angular/views/index.html",
                controller: "IndexController"
            });

            $stateProvider.state("contact", {
                url: "/contact",
                templateUrl: "/Angular/views/contact.html",
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

            $stateProvider.state("supply/create", {
                url: "/supply/create",
                templateUrl: "/Angular/views/supply/create.html",
                controller: "SupplyController"
            });

            $stateProvider.state("provider/index", {
                url: "/provider/index",
                templateUrl: "/Angular/views/provider/index.html",
                controller: "ProviderController"
            });

            $stateProvider.state("experse/index", {
                url: "/experse/index",
                templateUrl: "/Angular/views/experse/index.html",
                controller: "ExperseController"
            });

            $stateProvider.state("experse/create", {
                url: "/experse/create/:id",
                templateUrl: "/Angular/views/experse/create.html",
                controller: "ExperseController"
            });

            $stateProvider.state("costumer/index", {
                url: "/costumer/index",
                templateUrl: "/Angular/views/costumer/index.html",
                controller: "CostumerController"
            });

            $stateProvider.state("materialInStore/index", {
                url: "/materialInStore/index",
                templateUrl: "/Angular/views/materialInStore/index.html",
                controller: "MaterialInStoreController"
            });

            $stateProvider.state("kindMaterial/index", {
                url: "/kindMaterial/index",
                templateUrl: "/Angular/views/kindMaterial/index.html",
                controller: "KindMaterialController"
            });

            $urlRouterProvider.otherwise("/");
        }]);
})();