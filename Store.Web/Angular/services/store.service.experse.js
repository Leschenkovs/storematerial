(function () {
    "use strict";

    function ExperseService($rootScope, $http, $q) {

    };

    angular
        .module("store.WebUI.Services")
        .service("ExperseService", ["$rootScope", "$http", "$q", ExperseService]);

})();