(function () {
    "use strict";

    // register your service into a dependent module.
    function RoleService($rootScope, $http, $q) {

        this.getAllRoles = function () {
            var deferred = $q.defer();
            $http.get("api/role").
                success(function (data, status, headers, config) {
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
        .service("RoleService", ["$rootScope", "$http", "$q", RoleService]);
})();