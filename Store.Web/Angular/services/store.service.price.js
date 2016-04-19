(function () {
    "use strict";

    function PriceService($rootScope, $http, $q) {

    };

    angular
        .module("store.WebUI.Services")
        .service("PriceService", ["$rootScope", "$http", "$q", PriceService]);

})();