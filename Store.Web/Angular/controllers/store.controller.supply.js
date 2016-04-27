(function() {
    "use strict";

    var SupplyController = function ($scope, $state, $filter, SupplyService, ProviderService, UnitMaterialService, KindMaterialService, ngTableParams) {

        var originalData = [];

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
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

        ProviderService.getAllProviders().then(function (value) {
            $scope.providers = value;
        });

        UnitMaterialService.getAllUnitMaterials().then(function (value) {
            $scope.unitMaterials = value;
        });

        KindMaterialService.getAllKindMaterials().then(function (value) {
            $scope.kindMaterials = value;
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
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("SupplyController", ["$scope", "$state", "$filter", "SupplyService", "ProviderService", "UnitMaterialService", "KindMaterialService", "ngTableParams", SupplyController]);
})();