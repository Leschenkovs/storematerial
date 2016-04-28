(function () {
    "use strict";

    // controller class definintion
    var DoughtnutCtrl = function ($scope, $state, $timeout, MaterialInStoreService) {

        var materialInStore = [];

        MaterialInStoreService.getMaterialInStores().then(function (value) {
            materialInStore = angular.copy(value);
        });

        $scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
        $scope.data = [300, 500, 100];

    };


    angular
    .module("store.WebUI.Controllers")
    .controller("DoughtnutCtrl", ["$scope", "$state", "$timeout"," MaterialInStoreService", DoughtnutCtrl]);

})();