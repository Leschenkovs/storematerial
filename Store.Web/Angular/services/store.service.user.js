(function () {
    "use strict";

    // register your service into a dependent module.
    function UserService($rootScope, $http, $q) {
        this.getAllUsers = function () {
            var deferred = $q.defer();
            $http.get("api/user").
                success(function(data, status, headers, config) {
                    deferred.resolve(data);
                }).
            error(function (data, status, headers, config) {
                deferred.reject(status);
            });
            return deferred.promise;
        };
    };

    angular
        .module("store.WebUI.Services")
        .service("UserService", ["$rootScope", "$http", "$q", UserService]);
})();