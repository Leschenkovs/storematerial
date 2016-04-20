(function () {
    "use strict";

    // controller class definintion
    var UserController = function ($scope, $state, $filter, UserService, RoleService, ngTableParams) {
        var originalData = [];

        UserService.getAllUsers().then(function (value) {
            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 2 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

        $scope.cancel = function(row, rowForm) {
            var originalRow = resetRow(row, rowForm);
            angular.extend(row, originalRow);
        };

        function resetRow(row, rowForm) {
            row.isEditing = false;
            rowForm.$setPristine();
            for (var i in originalData) {
                if (originalData[i].id === row.id) {
                    return originalData[i];
                }
            }
        };

        $scope.update = function(row, rowForm) {
            if (rowForm.$valid) {
                UserService.updateUser(row).then(
                    function(response) {
                        row.roleName = $filter('filter')($scope.roles, { id: row.roleId }, true)[0].name;
                        var originalRow = resetRow(row, rowForm);
                        angular.extend(originalRow, row);
                    },
                    function(errorObject) {
                        alert(errorObject.ExceptionMessage);
                    });
            };
        };

        RoleService.getAllRoles().then(function (value) {
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

        $scope.save = function (user, createUser) {
            if (createUser.$valid) {
                UserService.addUser(user).then(
                    function(value) {
                        $state.go("user/index");
                    },
                    function(errorObject) {
                        alert(errorObject.ExceptionMessage);
                    });
            }
        };

        $scope.deleteUser = function (id) {
            UserService.deleteUser(id).then(function (value) {
                if (value) {
                    _.remove($scope.tableParams.settings().dataset, function (item) {
                        return id === item.id;
                    });
                    $scope.tableParams.reload().then(function (data) {
                        if (data.length === 0 && $scope.tableParams.total() > 0) {
                            $scope.tableParams.page($scope.tableParams.page() - 1);
                            $scope.tableParams.reload();
                        }
                    });
                }
            });
        };
    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("UserController", ["$scope", "$state", "$filter", "UserService", "RoleService", "ngTableParams", UserController]);
})();