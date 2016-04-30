// Footer directive

(function () {
    "use strict";

    // footer directive
    var footerDirective = function () {
        return {
            restrict: 'AE',
            replace: false,
            templateUrl: 'Angular/partials/footer.html'
        };
    };

    // register your directive into a dependent module.
    angular
        .module('store.WebUI.Directives')
        .directive("storeFooter", [footerDirective]);
})();