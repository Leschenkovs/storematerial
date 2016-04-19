(function() {
    "use strict";

    var ProviderController = function ($scope, $state, ProviderService) {

        ProviderService.getAllProviders().then(function (value) {
            $scope.providers = value;
        });

        $scope.provider =
        {
            name: "",
            address: "",
            telephone: "",
            description: ""
        };

        $scope.save = function (provider, createProvider) {
            if (createProvider.$valid) {
                ProviderService.addProvider(provider).then(function (value) {
                    $state.go("provider/index");
                });
            }
        };

        $scope.deleteProvider = function (id) {
            ProviderService.deleteProvider(id).then(function (value) {
                if (value) {
                    var index = -1;
                    var providerArr = eval($scope.providers);
                    for (var i = 0; i < providerArr.length; i++) {
                        if (providerArr[i].id === id) {
                            index = i;
                            break;
                        }
                    }
                    if (index === -1) {
                        alert("Ошибка удаления записи из таблицы.");
                    }
                    $scope.providers.splice(index, 1);
                }
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("ProviderController", ["$scope", "$state", "ProviderService", ProviderController]);
})();