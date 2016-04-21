(function () {
    "use strict";

    function PriceService($rootScope, $http, $q) {

        this.getAllPrices = function () {
            var deferrred = $q.defer();
            $http.get("api/price").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(data);
            });
            return deferrred.promise;
        };

        this.getByIdMaterial = function (id) {
            var deferred = $q.defer();
            $http.get("api/price?id=" + id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };

        this.addPrice = function (entity) {
            var deferred = $q.defer();
            $http.post("api/price", entity).
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
        .service("PriceService", ["$rootScope", "$http", "$q", PriceService]);

})();