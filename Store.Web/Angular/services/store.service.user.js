(function () {
    "use strict";

    // register your service into a dependent module.
    function userService($rootScope, $http, $q, logger) {
        this.getAllUsers = function () {
            // return $http({ method: 'GET', url: "/Angular/services/viewalldata1.json" });
            return $.ajax({
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                url: 'http://localhost:8062/api/user'
            });
        };
    }

    angular
        .module("store.WebUI.Services")
        .service("UserService", ["$rootScope", "$http", "$q", "logger", userService]);
})();