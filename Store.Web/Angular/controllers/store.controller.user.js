(function () {
    "use strict";

    // controller class definintion
    var UserController = function ($scope, $state, $filter, $location, UserService, RoleService, ngTableParams) {

        var originalData = [];

        UserService.getAllUsers().then(
            function (value) {
                originalData = angular.copy(value);
                $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                    filterDelay: 0,
                    dataset: angular.copy(value)
                });
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });

        $scope.cancel = function (row, rowForm) {
            var originalRow = resetRow(row, rowForm);
            angular.extend(row, originalRow);
        };

        $scope.cancelForm = function () {
            $state.go("user/index");
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

        function udateOrDeleteCurrentUser(userid) {
            if ($scope.$root.globals.currentUser.userid === userid) {
                $location.path('/login');
            }
        }

        $scope.update = function (row, rowForm) {
            if (rowForm.$valid) {
                UserService.updateUser(row).then(
                    function (response) {
                        row.roleName = $filter('filter')($scope.roles, { id: row.roleId }, true)[0].name;
                        var originalRow = resetRow(row, rowForm);
                        angular.extend(originalRow, row);
                        udateOrDeleteCurrentUser(row.id);
                    },
                    function (errorObject) {
                        bootbox.alert(errorObject.ExceptionMessage);
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
                    function (value) {
                        $state.go("user/index");
                    },
                    function (errorObject) {
                        bootbox.alert(errorObject.ExceptionMessage);
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
                    udateOrDeleteCurrentUser(id);
                }
            });
        };;
    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("UserController", ["$scope", "$state", "$filter", "$location", "UserService", "RoleService", "ngTableParams", UserController]);
})();