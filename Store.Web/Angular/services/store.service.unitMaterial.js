(function () {
    "use strict";

    function UnitMaterialService($rootScope, $http, $q) {

        this.getAllUnitMaterials = function () {
            var deferrred = $q.defer();
            $http.get("api/unitMaterial").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(status);
            });
            return deferrred.promise;
        };

        this.getByKindMaterialId = function (id) {
            var deferrred = $q.defer();
            $http.get("api/unitMaterial?id=" + id).success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(status);
            });
            return deferrred.promise;
        };

        this.deleteUnitMaterial = function (id) {
            var deferred = $q.defer();
            $http.delete("api/unitMaterial?id=" + id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        };

        this.addUnitMaterial = function (entity) {
            var deferred = $q.defer();
            $http.post("api/unitMaterial", entity).
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
        .service("UnitMaterialService", ["$rootScope", "$http", "$q", UnitMaterialService]);

})();