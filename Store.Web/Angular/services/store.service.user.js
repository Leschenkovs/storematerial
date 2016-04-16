(function () {
    "use strict";

    // register your service into a dependent module.
    function UserService($rootScope, $http, $q) {
        this.getAllUsers = function () {
            var deferred = $q.defer();
            $http.get("http://localhost:8062/api/user").then(function(response) {
                debugger;
                deferred.resolve(response);
            });
            debugger;
            return deferred.promise;
            
            return $.ajax({
                type: 'GET',
                async: false,
                contentType: 'application/json; charset=utf-8',
                url: 'http://localhost:8062/api/user'
            });
        };
    };

    angular
        .module("store.WebUI.Services")
        .service("UserService", ["$rootScope", "$http", "$q", UserService]);
})();