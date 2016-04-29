(function() {
    "use strict";

    var SupplyController = function ($scope, $state, $filter, $rootScope, SupplyService, ProviderService, UnitMaterialService, KindMaterialService, ngTableParams) {

        var originalData = [];
        $scope.isWriteRole = $rootScope.writeRole;

        $scope.supply =
        {
            id: "",
            count: "",
            ttn: "",
            priceSupply:"",
            unitMaterialId: "",
            providerId: "",
            materialInStoreId: ""
        };

        $scope.cancel = function () {
            $state.go("supply/index");
        };

        SupplyService.getAllSupplies().then(function (value) {
            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 10 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        ProviderService.getAllProviders().then(function (value) {
            $scope.providers = value;
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        UnitMaterialService.getAllUnitMaterials().then(function (value) {
            $scope.unitMaterials = value;
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        KindMaterialService.getAllKindMaterials().then(function (value) {
            $scope.kindMaterials = value;
        },
        function (errorObject) {
            bootbox.alert(errorObject.ExceptionMessage);
        });

        $scope.save = function (supply, createSupply) {
            if (createSupply.$valid) {
                SupplyService.addSupply(supply).then(
                    function (value) {
                        $state.go("supply/index");
                    },
                    function (errorObject) {
                        bootbox.alert(errorObject.ExceptionMessage);
                    });
            } else {
                bootbox.alert("Заполните все поля!");
            }
        };

        $scope.deleteSupply = function (id) {
            SupplyService.deleteSupply(id).then(function (value) {
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
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("SupplyController", ["$scope", "$state", "$filter", "$rootScope", "SupplyService", "ProviderService", "UnitMaterialService", "KindMaterialService", "ngTableParams", SupplyController]);
})();