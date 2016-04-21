(function() {
    "use strict";

    function ProviderService($rootScope, $http, $q) {

        this.getAllProviders = function() {
            var deferrred = $q.defer();
            $http.get("api/provider").success(function(data) {
                deferrred.resolve(data);
            }).error(function(data, status) {
                deferrred.reject(data);
            });
            return deferrred.promise;
        };

        this.addProvider = function (entity) {
            var deferred = $q.defer();
            $http.post("api/provider", entity).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };

        this.deleteProvider = function (id) {
            var deferred = $q.defer();

            $http.delete("api/provider?id=" + id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };

        this.updateProvider = function (entity) {
            var deferred = $q.defer();
            $http.put("api/provider", entity).
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
        .service("ProviderService", ["$rootScope", "$http", "$q", ProviderService]);

})();