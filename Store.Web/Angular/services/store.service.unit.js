(function () {
    "use strict";

    function UnitService($rootScope, $http, $q) {

        this.getAllUnits = function () {
            var deferred = $q.defer();
            $http.get("api/unit").
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
        .service("UnitService", ["$rootScope", "$http", "$q", UnitService]);

})();