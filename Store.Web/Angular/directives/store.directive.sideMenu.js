// sideMenu directive

(function () {
    "use strict";

    // sideMenu directive
    var sidemenuDirective = function () {
        return {
            restrict: 'EA',
            replace: true,
            templateUrl: 'Angular/partials/sidemenu.html',
            controller: function($scope) {}
        };
    };

    // register your directive into a dependent module.
    angular
        .module('store.WebUI.Directives')
        .directive("sideMenu", [sidemenuDirective]);
})();