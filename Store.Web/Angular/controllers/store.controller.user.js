(function () {
    "use strict";

    // controller class definintion
    var UserController = function ($scope, $state, UserService) {

        //$scope.model = {};
        //$scope.model.pageSizeList = UserService.getPageSizeList(); // list
        //$scope.showProductList = true;

        UserService.getAllUsers().then(function (value) {
            $scope.users = value.Users;
            $scope.roles = value.Roles;
        });


        $scope.user = 
        {
            Tn: "",
            Fio: "",
            Position: "",
            Department: "",
            RoleId: ""
        };

        $scope.save = function (user, createUser) {
            if (createUser.$valid) {
                // return listUser
                //click("#cancel");

                UserService.addUser(user).then(function (value) {
                    $scope.user.Tn = value.Tn + "!!!!!!";
                });
            }
        };

        //Called from on-data-required directive.
        //$scope.onServerSideItemsRequested = function (currentPage, pageItems, filterBy, filterByFields, orderBy, orderByReverse) {
        //    //loadUserList(currentPage, pageItems, orderBy, orderByReverse);
        //    //$timeout(loadProductList(currentPage, pageItems, orderBy, orderByReverse), 3000);
        //    UserService.getAllUsers().then(function (value) {
        //        $scope.model.users = value.Users;
        //        $scope.model.TotalCount = value.TotalCount;
        //    });
        //};


        //Default paging and sorting paramters.
        //var pCurrentPage = 0; //PageIndex
        //var pPageItems = 5;   //PageSize  
        //var pOrderBy = "";    //SortBy
        //var pOrderByReverse = false;  //SortDirection = 0
        //var resetSearchFlag = false;

        //Set search items for starting and reset.
        //var initiateSearchItems = function() {
        //    $scope.model.pSearchType = { selected: "0" };
        //    $scope.model.pStatusType = { selected: 0 };
        //    $scope.model.pPageSizeObj = { selected: 5 };

        //    $scope.showProductList = true;
        //};
        //initiateSearchItems();

    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("UserController", ["$scope", "$state", "UserService", UserController]);
})();