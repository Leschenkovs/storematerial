(function () {
    "use strict";

    // register your service into a dependent module.
    function userService($rootScope, $http, $q, logger) {

    }

    angular
        .module("store.WebUI.Services")
        .service("UserService", ["$rootScope", "$http", "$q", "logger", userService]);
})();