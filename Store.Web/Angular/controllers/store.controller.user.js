(function () {
    "use strict";

    // controller class definintion
    var UserController = function ($scope, $state, UserService) {

        UserService.getAllUsers().then(function (value) { $scope.users = value; });
    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("UserController", ["$scope", "$state", "UserService", UserController]);
})();