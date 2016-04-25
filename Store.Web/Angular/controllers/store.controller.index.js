(function () {
    "use strict";

    // controller class definintion
    var IndexController = function ($scope, $state) {
        $('.carousel').carousel({
            interval: 3000 //changes the speed
        });
    };

    // register your controller into a dependent module 
    angular
        .module("store.WebUI.Controllers")
        .controller("IndexController", ["$scope", "$state", IndexController]);

})();