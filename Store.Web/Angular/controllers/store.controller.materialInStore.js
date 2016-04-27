(function () {
    "use strict";

    var MaterialInStoreController = function ($scope, $state, $filter, MaterialInStoreService, PriceService, ngTableParams) {


        // TABLES

        var originalData = [];
        var originalDataPrice = [];
        $scope.isCollapsed = false;

        $scope.createPrice =
        {
            id: "",
            priceValue: "",
            dateOt: "",
            materialInStoreId: 0
        };

        $scope.selectedMaterial =
        {
            materialInStoreId:0,
            name: "",
            unit: ""
        };

// Materials
        MaterialInStoreService.getMaterialInStores().then(function (value) {
            originalData = angular.copy(value);
            $scope.tableParams = new ngTableParams({ page: 1, count: 12 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

        $scope.setSelected = function (unitMaterialId) {
            var a = _.find(originalData, function (rw) { return rw.unitMaterialId === unitMaterialId; });
            $scope.selectedMaterial.name = a.kindMaterialName;
            $scope.selectedMaterial.unit = a.unitName;
            $scope.selectedMaterial.materialInStoreId = a.unitMaterialId;

            $scope.createPrice.materialInStoreId = unitMaterialId;
        };

        $scope.createExperse = function(unitMaterialId) {
            var dateNow = new Date();
            var arr = _.filter(originalDataPrice, function (rw) {
                return rw.materialInStoreId === unitMaterialId && new Date(rw.dateOt).getMonth() == dateNow.getMonth() && new Date(rw.dateOt).getYear() == dateNow.getYear();
            });

            if (arr.length == 0) {
                bootbox.alert("Отсутствует цена реализации на текущий месяц для материала! Отгрузка невозможна!");
            } else {
                $state.go('experse/create', { id: unitMaterialId });
            }
        };

// Prices
        PriceService.getAllPrices().then(function (value) {
            originalDataPrice = angular.copy(value);
            $scope.tableParamsPrice = new ngTableParams({ page: 1, count: 12 }, {
                filterDelay: 0,
                dataset: angular.copy(value)
            });
        });

        $scope.cancel = function (rowPrice, rowFormPrice) {
            var originalRow = resetRow(rowPrice, rowFormPrice);
            angular.extend(rowPrice, originalRow);
        };

        function resetRow(rowPrice, rowFormPrice) {
            rowPrice.isEditing = false;
            rowFormPrice.$setPristine();
            for (var i in originalDataPrice) {
                if (originalDataPrice[i].id === rowPrice.id) {
                    return originalDataPrice[i];
                }
            }
        };

        function removeRow(id) {
            for (var i in originalDataPrice) {
                if (originalDataPrice[i].id === id) {
                    return originalDataPrice.splice(i, 1);
                }
            }
        };

        $scope.update = function (rowPrice, rowFormPrice) {
            PriceService.updatePrice(rowPrice).then(function (value) {
                var originalRow = resetRow(rowPrice, rowFormPrice);
                angular.extend(originalRow, rowPrice);
            },
            function (errorObject) {
                bootbox.alert(errorObject.ExceptionMessage);
            });
        };

        $scope.save = function(createPrice, createPriceForm) {
            if (createPriceForm.$valid) {
                PriceService.addPrice(createPrice).then(function (value) {
                    $scope.createPrice.id = "";
                    $scope.createPrice.priceValue = "";
                    $scope.createPrice.dateOt = new Date();

                    originalDataPrice.push(value);
                    $scope.tableParamsPrice.settings().dataset.unshift(value);
                    $scope.tableParamsPrice.reload().then(function(data) {
                        if (data.length === 0 && $scope.tableParamsPrice.total() > 0) {
                            $scope.tableParamsPrice.page($scope.tableParamsPrice.page() - 1);
                            $scope.tableParamsPrice.reload();
                        }
                    });
                },
                function (errorObject) {
                    bootbox.alert(errorObject.ExceptionMessage);
                });
            }
        };

        $scope.delete = function (id) {
            PriceService.deletePrice(id).then(function (value) {
                if (value) {
                    removeRow(id);
                    _.remove($scope.tableParamsPrice.settings().dataset, function (item) {
                        return id === item.id;
                    });
                    $scope.tableParamsPrice.reload().then(function (data) {
                        if (data.length === 0 && $scope.tableParamsPrice.total() > 0) {
                            $scope.tableParamsPrice.page($scope.tableParamsPrice.page() - 1);
                            $scope.tableParamsPrice.reload();
                        }
                    });
                }
            },
             function (errorObject) {
                 bootbox.alert(errorObject.ExceptionMessage);
             });
        };


        // DATEPICKER
        $scope.today = function () {
            $scope.createPrice.dateOt = new Date();
        };
        $scope.today();
        $scope.clear = function () {
            $scope.createPrice.dateOt = null;
        };
        $scope.inlineOptions = {
            minDate: new Date(),
        };
        $scope.dateOptions = {
            formatYear: 'yy',
            maxDate: new Date(2019, 12, 1),
            minDate: new Date(),
            minMode: 'month'
        };

        $scope.toggleMin = function () {
            $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
            $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
        };
        $scope.toggleMin();
        $scope.open = function () {
            $scope.popup.opened = true;
        };
        $scope.setDate = function (year, month) {
            $scope.createPrice.dateOt = new Date(year, month);
        };
        $scope.format = 'MMMM-yyyy';
        $scope.popup = {
            opened: false
        };
    };

    angular
        .module("store.WebUI.Controllers")
        .controller("MaterialInStoreController", ["$scope", "$state", "$filter", "MaterialInStoreService", "PriceService", "ngTableParams", MaterialInStoreController]);
})();