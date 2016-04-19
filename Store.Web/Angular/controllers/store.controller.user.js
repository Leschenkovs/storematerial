(function () {
    "use strict";

    // controller class definintion
    var UserController = function ($scope, $state, $filter, UserService, RoleService, ngTableParams) {
        var originalData = [];

        UserService.getAllUsers().then(function (value) {
            $scope.users = value;

            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({}, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });

            $scope.usersTable = new ngTableParams({
                page: 1,
                count: 2
            }, {
                total: $scope.users.length,
                getData: function ($defer, params) {
                    $scope.data = params.sorting() ? $filter('orderBy')($scope.users, params.orderBy()) : $scope.users;
                    $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                    $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                    $defer.resolve($scope.data);
                }
            });
        });

        $scope.cancel = function (row, rowForm) {
            var originalRow = resetRow(row, rowForm);
            angular.extend(row, originalRow);
        }

        $scope.del = function (row) {
            /*_.remove(self.tableParams.settings().dataset, function (item) {
                return row === item;
            });
            self.tableParams.reload().then(function (data) {
                if (data.length === 0 && self.tableParams.total() > 0) {
                    self.tableParams.page(self.tableParams.page() - 1);
                    self.tableParams.reload();
                }
            });*/
        }

        function resetRow(row, rowForm) {
            row.isEditing = false;
            rowForm.$setPristine();
            /*$scope.tableTracker.untrack(row);
            return _.findWhere(originalData, function (r) {
                return r.id === row.id;
            });*/
            for (var i in originalData) {
                if (originalData[i].id === row.id) {
                    return originalData[i];
                }
            }
        }

        function save(row, rowForm) {
            //var originalRow = resetRow(row, rowForm);
            //angular.extend(originalRow, row);
        }

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
                UserService.addUser(user).then(function (value) {
                    $state.go("user/index");
                });
            }
        };

        $scope.deleteUser = function (id) {
            debugger;
            UserService.deleteUser(id).then(function (value) {
                if (value) {
                    var index = -1;
                    var userArr = eval($scope.usersTable.data);
                    for (var i = 0; i < userArr.length; i++) {
                        if (userArr[i].id === id) {
                            index = i;
                            break;
                        }
                    }
                    if (index === -1) {
                        alert("Ошибка удаления записи из таблицы.");
                    }
                    $scope.usersTable.data.splice(index, 1);
                }
            });
        };

    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("UserController", ["$scope", "$state", "$filter", "UserService", "RoleService", "ngTableParams", UserController]);
})();