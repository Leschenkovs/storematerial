(function () {
    "use strict";

    function ExperseService($rootScope, $http, $q) {

        this.getCreateExperseByMaterialInSoreId = function (id) {
            var deferred = $q.defer();

            $http.get("api/experse?materialInStoreId=" + id).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
            return deferred.promise;
        };


        this.addExperse = function (entity) {
            var deferred = $q.defer();
            $http.post("api/experse", entity).
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
        .service("ExperseService", ["$rootScope", "$http", "$q", ExperseService]);

})();