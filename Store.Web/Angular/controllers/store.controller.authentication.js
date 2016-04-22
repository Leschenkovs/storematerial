﻿(function () {
    "use strict";

    var AuthenticationController = function ($scope, $rootScope, $location, AuthenticationService) {
        // reset login status
        AuthenticationService.ClearCredentials();

        $scope.login = function () {
            $scope.dataLoading = true;
            AuthenticationService.Login($scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthenticationService.SetCredentials($scope.username, $scope.password, response.user);
                    $location.path('/');
                } else {
                    $scope.error = response.message;
                    $scope.dataLoading = false;
                }
            });
        };
    }

    angular
        .module("store.WebUI.Controllers")
        .controller("AuthenticationController", ["$scope", "$rootScope", "$location", "AuthenticationService", AuthenticationController]);
})();