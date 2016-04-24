(function () {
    "use strict";

    var ExperseController = function ($scope, $state, CostumerService,ExperseService) {

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

        ExperseService.getCreateExperseByMaterialInSoreId($state.params.id).then(function (response) {
            $scope.experse.lostCount = response.lostCount;
            $scope.experse.unitShortName = response.unitShortName;
            $scope.experse.kindMaterialName = response.kindMaterialName;
            $scope.experse.materialInStoreId = response.materialInStoreId;
            },
        function (errorObject) {
            alert(errorObject.ExceptionMessage);
        });

        CostumerService.getAllCostumers().then(function (value) {
            $scope.costumers = value;
        });

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
        .controller("ExperseController", ["$scope", "$state","CostumerService", "ExperseService", ExperseController]);
})();