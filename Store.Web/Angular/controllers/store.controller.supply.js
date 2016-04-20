(function() {
    "use strict";

    var SupplyController = function ($scope, $state, $filter, SupplyService, ProviderService, UnitMaterialService, KindMaterialService) {

        $scope.supply =
        {
            id: "",
            count: "",
            ttn:"",
            unitMaterialId: "",
            providerId: "",
            materialInStoreId: ""
        };

        SupplyService.getAllSupplies().then(function (value) {
            $scope.supplies = value;
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

    };

    angular
        .module("store.WebUI.Controllers")
        .controller("SupplyController", ["$scope", "$state", "$filter", "SupplyService", "ProviderService", "UnitMaterialService", "KindMaterialService", SupplyController]);
})();