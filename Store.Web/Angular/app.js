(function () {
    "use strict";

    //angular.module("store.WebUI.Services", []);
    //angular.module("store.WebUI.Directives");
    angular.module("store.WebUI.Controllers", []);
    //angular.module("store.WebUI.Factories", []);
    //angular.module("store.WebUI.Helpers", []);
    angular.module("store.WebUI.Externals", ["ui.router"]);

    var app = angular.module("store.WebUI", ["store.WebUI.Externals", "store.WebUI.Controllers"]);
})();