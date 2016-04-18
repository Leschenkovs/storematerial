(function () {
    "use strict";

    // controller class definintion
    var UserController = function($scope, $state, UserService, RoleService) {

        UserService.getAllUsers().then(function(value) {
            $scope.users = value;
        });

        RoleService.getAllRoles().then(function(value) {
            $scope.roles = value;
        });

        $scope.user =
        {
            tn: "",
            fio: "",
            position: "",
            department: "",
            roleId: ""
        };

        $scope.save = function(user, createUser) {
            if (createUser.$valid) {
                UserService.addUser(user).then(function(value) {
                    $state.go("user/index");
                });
            }
        };

        $scope.deleteUser = function (id) {
            UserService.deleteUser(id).then(function(value) {
                if (value) {
                    var index = -1;
                    var userArr = eval($scope.users);
                    for (var i = 0; i < userArr.length; i++) {
                        if (userArr[i].id === id) {
                            index = i;
                            break;
                        }
                    }
                    if (index === -1) {
                        alert("Something gone wrong");
                    }
                    $scope.users.splice(index, 1);
                }
            });
        };
    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("UserController", ["$scope", "$state", "UserService", "RoleService", UserController]);
})();