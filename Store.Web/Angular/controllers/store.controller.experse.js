(function () {
    "use strict";

    var ExperseController = function($scope, $rootScope, $state, $filter, CostumerService, ExperseService, ngTableParams) {

        var originalData = [];
        var passMaterialInStoreId = $state.params.id;
        var stateName = $state.current.name;

        $scope.experse =
        {
            id: "",
            count: "",
            lostCount: "",
            materialInStoreId: "",
            costumerId: "",
            userId: "",
            kindMaterialName: "",
            unitShortName: ""
        };


        if (stateName === "experse/index") {
            ExperseService.getAllExperses().then(function(value) {
                originalData = angular.copy(value);
                $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                    filterDelay: 0,
                    dataset: angular.copy(value)
                });
            });
        }


        if (stateName === "experse/create") {
            ExperseService.getCreateExperseByMaterialInSoreId(passMaterialInStoreId).then(function(response) {
                    $scope.experse.lostCount = response.lostCount;
                    $scope.experse.unitShortName = response.unitShortName;
                    $scope.experse.kindMaterialName = response.kindMaterialName;
                    $scope.experse.materialInStoreId = response.materialInStoreId;
                    $scope.experse.userId = $rootScope.globals.currentUser.userid;
                },
                function(errorObject) {
                    bootbox.alert(errorObject.ExceptionMessage);
                });

            CostumerService.getAllCostumers().then(function(value) {
                $scope.costumers = value;
            });

            $scope.save = function(experse, createExperse) {
                if (createExperse.$valid) {
                    ExperseService.addExperse(experse).then(
                        function(response) {
                            passMaterialInStoreId = "";
                            $state.go("materialInStore/index");
                        },
                        function(errorObject) {
                            passMaterialInStoreId = "";
                            bootbox.alert(errorObject.ExceptionMessage);
                        });
                }
            };

            $scope.cancel = function() {
                $state.go("materialInStore/index");
            };
        }

    };

    angular
        .module("store.WebUI.Controllers")
        .controller("ExperseController", ["$scope", "$rootScope", "$state", "$filter", "CostumerService", "ExperseService", "ngTableParams", ExperseController]);
})();