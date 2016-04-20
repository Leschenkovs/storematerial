(function () {
    "use strict";

    // register your service into a dependent module.
    function UserService($rootScope, $http, $q) {

        this.getAllUsers = function() {
            var deferred = $q.defer();
            $http.get("api/user").
                success(function(data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function(data, status, headers, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        };

        this.addUser = function (entity) {
            var deferred = $q.defer();
            $http.post("api/user", entity).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };

        this.updateUser = function (entity) {
            var deferred = $q.defer();
            $http.put("api/user", entity).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };

        this.deleteUser = function (id) {
            var deferred = $q.defer();

            $http.delete("api/user?id="+id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };
    };

    angular
        .module("store.WebUI.Services")
        .service("UserService", ["$rootScope", "$http", "$q", UserService]);
})();