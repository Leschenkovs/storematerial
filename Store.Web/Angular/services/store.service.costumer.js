(function () {
    "use strict";

    function CostumerService($rootScope, $http, $q) {

        this.getAllCostumers = function () {
            var deferrred = $q.defer();
            $http.get("api/costumer").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(status);
            });
            return deferrred.promise;
        };

        this.addCostumer = function (entity) {
            var deferred = $q.defer();
            $http.post("api/costumer", entity).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        };

        this.deleteCostumer = function (id) {
            var deferred = $q.defer();

            $http.delete("api/costumer?id=" + id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        };

        this.updateCostumer = function (entity) {
            var deferred = $q.defer();
            $http.put("api/costumer", entity).
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
        .service("CostumerService", ["$rootScope", "$http", "$q", CostumerService]);

})();