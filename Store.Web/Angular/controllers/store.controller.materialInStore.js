(function () {
    "use strict";

    var MaterialInStoreController = function ($scope, $state, $filter, MaterialInStoreService, ngTableParams) {

        var originalData = [];

        MaterialInStoreService.getMaterialInStores().then(function (value) {
            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("MaterialInStoreController", ["$scope", "$state", "$filter", "MaterialInStoreService", "ngTableParams", MaterialInStoreController]);
})();