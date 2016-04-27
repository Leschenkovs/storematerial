﻿// userInfo directive

(function () {
    "use strict";

    // userInfo directive
    var userinfoDirective = function () {
        return {
            restrict: 'EA',
            replace: true,
            templateUrl: 'Angular/partials/userinfo.html',
            controller: function($scope) {}
        };
    };

    // register your directive into a dependent module.
    angular
        .module('store.WebUI.Directives')
        .directive("userInfo", [userinfoDirective]);
})();