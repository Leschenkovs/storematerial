(function () {
    "use strict";

    function MaterialInStoreService($rootScope, $http, $q) {

        this.getMaterialInStores = function () {
            var deferrred = $q.defer();
            $http.get("api/materialInStore").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data, status) {
                deferrred.reject(data);
            });
            return deferrred.promise;
        };

    };

    angular
        .module("store.WebUI.Services")
        .service("MaterialInStoreService", ["$rootScope", "$http", "$q", MaterialInStoreService]);

})();