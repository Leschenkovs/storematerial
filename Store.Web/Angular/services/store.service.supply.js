(function() {
    "use strict";

    function SupplyService($rootScope, $http, $q) {
        
        this.getAllSupplies = function () {
            var deferrred = $q.defer();
            $http.get("api/supply").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(status);
            });
            return deferrred.promise;
        };

        this.addSupply = function (entity) {
            var deferred = $q.defer();
            $http.post("api/supply", entity).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };

        this.deleteSupply = function (id) {
            var deferred = $q.defer();

            $http.delete("api/supply?id=" + id).
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
        .service("SupplyService", ["$rootScope", "$http", "$q", SupplyService]);

})();