(function () {
    "use strict";

    // controller class definintion
    var IndexController = function ($scope, $state) {

    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("IndexController", ["$scope", "$state", IndexController]);

})();