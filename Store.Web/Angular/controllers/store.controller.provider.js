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

        $scope.save = function(provider, createProvider) {
            if (createProvider.$valid) {
                if (provider.id != null && provider.id != 'undefined' && provider.id != "") {
                    ProviderService.updateProvider(provider).then(function (value) {
                        alert(value);
                        $scope.provider =
                        {
                            name: "",
                            address: "",
                            telephone: "",
                            description: ""
                        };
                    });
                } else {
                    ProviderService.addProvider(provider).then(function(value) {
                        $scope.providers.push({
                            'id': value.id,
                            'name': value.name,
                            'address': value.address,
                            'telephone': value.telephone,
                            'description': value.description
                        });
                        $scope.provider =
                        {
                            id: "",
                            name: "",
                            address: "",
                            telephone: "",
                            description: ""
                        };
                    });
                }
            }
        };

        $scope.updateProvider = function (index) {
            $scope.provider = $scope.providers[index];
        };

        $scope.deleteProvider = function (index) {
            var id = $scope.providers[index].id;
            ProviderService.deleteProvider(id).then(function (value) {
                if (value) {
                    $scope.providers.splice(index, 1);
                }
            });
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("ProviderController", ["$scope", "$state", "ProviderService", ProviderController]);
})();