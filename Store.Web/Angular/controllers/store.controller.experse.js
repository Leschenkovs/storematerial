(function () {
    "use strict";

    var ExperseController = function ($scope,$rootScope, $state, $filter, CostumerService, ExperseService, ngTableParams) {

        var originalData = [];
        var passMaterialInStoreId = $state.params.id;

        $scope.experse =
        {
            id: "",
            count: "",
            lostCount: "",
            materialInStoreId: "",
            costumerId: "",
            userId: "",
            kindMaterialName: "",
            unitShortName:""
        };


        if (passMaterialInStoreId === "undefined" || passMaterialInStoreId === null) {
            ExperseService.getAllExperses().then(function(value) {
                originalData = angular.copy(value);
                $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                    filterDelay: 0,
                    dataset: angular.copy(value)
                });
            });
        }


        if (passMaterialInStoreId != "undefined" && passMaterialInStoreId != null) {
            ExperseService.getCreateExperseByMaterialInSoreId(passMaterialInStoreId).then(function (response) {
                    $scope.experse.lostCount = response.lostCount;
                    $scope.experse.unitShortName = response.unitShortName;
                    $scope.experse.kindMaterialName = response.kindMaterialName;
                    $scope.experse.materialInStoreId = response.materialInStoreId;
                    $scope.experse.userId = $rootScope.globals.currentUser.userid;
                },
                function(errorObject) {
                    alert(errorObject.ExceptionMessage);
                });

            CostumerService.getAllCostumers().then(function(value) {
                $scope.costumers = value;
            });
        }

        $scope.save = function (experse, createExperse) {
            if (createExperse.$valid) {
                ExperseService.addExperse(experse).then(
                    function (response) {
                        $state.go("materialInStore/index");
                    },
                    function (errorObject) {
                        alert(errorObject.ExceptionMessage);
                    });
            }
        };

    };

    angular
        .module("store.WebUI.Controllers")
        .controller("ExperseController", ["$scope", "$rootScope", "$state", "$filter", "CostumerService", "ExperseService", "ngTableParams", ExperseController]);
})();