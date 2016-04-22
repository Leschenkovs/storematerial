(function () {
    "use strict";

    var MaterialInStoreController = function ($scope, $state, $filter, MaterialInStoreService, PriceService, ngTableParams) {

        // DATEPICKER
        $scope.today = function () {
            $scope.dt = new Date();
        };
        $scope.today();

        $scope.clear = function () {
            $scope.dt = null;
        };

        $scope.inlineOptions = {
            minDate: new Date(),
        };

        $scope.dateOptions = {
            dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2019, 12, 1),
            minDate: new Date(),
            //startingDay: 1,
            minMode: 'month'
        };

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        $scope.toggleMin = function () {
            $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
            $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
        };

        $scope.toggleMin();

        $scope.open = function () {
            $scope.popup.opened = true;
        };

        $scope.setDate = function (year, month) {
            $scope.dt = new Date(year, month);
        };

        $scope.format = 'MMMM-yyyy';

        $scope.popup = {
            opened: false
        };

        // TABLES

        var originalData = [];
        var originalDataPrice = [];
        $scope.choiceMaterial = 0;

        MaterialInStoreService.getMaterialInStores().then(function (value) {
            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 5 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

        $scope.changeMaterial = function (unitMaterialId) {
            $scope.choiceMaterial = unitMaterialId;
        };

        $scope.createPrice =
        {
            id: "",
            priceValue: "",
            dateOt: "",
            materialInStoreId: ""
        };

        //PriceService.getAllPrices().then(function (value) {
        //    originalDataPrice = angular.copy(value);
        //    $scope.tableParamsPrice = new ngTableParams({ page: 1, count: 5 }, {
        //        filterDelay: 0,
        //        dataset: angular.copy(value)
        //    });
        //});

        //$scope.cancel = function (rowPrice, rowFormPrice) {
        //    var originalRow = resetRow(rowPrice, rowFormPrice);
        //    angular.extend(rowPrice, originalRow);
        //};

        //function resetRow(rowPrice, rowFormPrice) {
        //    rowPrice.isEditing = false;
        //    rowFormPrice.$setPristine();
        //    for (var i in originalDataPrice) {
        //        if (originalDataPrice[i].id === rowPrice.id) {
        //            return originalDataPrice[i];
        //        }
        //    }
        //};

        //$scope.save = function (createPrice, createPriceForm) {
        //    if (createPriceForm.$valid) {
        //        PriceService.addPrice(createPrice).then(function (value) {
        //            if (value) {
        //                $scope.tableParamsPrice.settings().dataset.unshift({
        //                    id: "",
        //                    priceValue: value.priceValue,
        //                    dateOt: value.priceValue,
        //                    materialInStoreId: value.priceValue
        //                });
        //                $scope.tableParams.reload().then(function (data) {
        //                    if (data.length === 0 && self.tableParams.total() > 0) {
        //                        self.tableParams.page(self.tableParams.page() - 1);
        //                        self.tableParams.reload();
        //                    }
        //                });
        //                $scope.costumer =
        //                {
        //                    id: "",
        //                    name: "",
        //                    address: "",
        //                    telephone: "",
        //                    description: ""
        //                };
        //            } else {
        //                alert("Ошибка добавления записи!");
        //            };
        //        });
        //    }
        //};
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("MaterialInStoreController", ["$scope", "$state", "$filter", "MaterialInStoreService", "PriceService", "ngTableParams", MaterialInStoreController]);
})();