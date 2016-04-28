(function () {
    "use strict";

    // controller class definintion
    var DoughtnutCtrl = function ($scope, $state, $timeout, MaterialInStoreService) {

        var materialInStore = [];
        $scope.dateNow = new Date();

        MaterialInStoreService.getMaterialInStores().then(function(value) {
            materialInStore = angular.copy(value);

            $scope.labels = materialInStore.map(function(a) { return a.kindMaterialName + ', ' + a.unitName; });
            $scope.data = materialInStore.map(function(a) { return a.count; });
    });

    };


    angular
    .module("store.WebUI.Controllers")
    .controller("DoughtnutCtrl", ["$scope", "$state", "$timeout","MaterialInStoreService", DoughtnutCtrl]);

})();