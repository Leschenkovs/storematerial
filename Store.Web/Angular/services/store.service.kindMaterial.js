(function () {
    "use strict";

    function KindMaterialService($rootScope, $http, $q) {

        this.getAllKindMaterials = function () {
            var deferrred = $q.defer();
            $http.get("api/kindMaterial").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(status);
            });
            return deferrred.promise;
        };

        this.addKindMaterial = function (entity) {
            var deferred = $q.defer();
            $http.post("api/kindMaterial", entity).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        };

        this.deleteKindMaterial = function (id) {
            var deferred = $q.defer();
            $http.delete("api/kindMaterial?id=" + id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        };

        this.updateKindMaterial = function (entity) {
            var deferred = $q.defer();
            $http.put("api/kindMaterial", entity).
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
        .service("KindMaterialService", ["$rootScope", "$http", "$q", KindMaterialService]);

})();