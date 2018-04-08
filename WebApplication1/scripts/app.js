var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(function ($routeProvider) {

    $routeProvider

        .when('/', {
            templateUrl: 'pages/homePage.html',
            controller: 'mainController'
        })

});

myApp.controller('mainController', ['$scope', '$log', '$timeout', '$filter', '$http', '$location',
    function (Scope, Log, Timer, Filter, Http, Location)
{
    // VALUES
    Scope.NUM_CHAR = 5;
    Scope.URI_RATES = 'api/rates';
    Scope.URI_TRANS = 'api/trans';
    // END VALUES

    // TEXTS
    Scope.Title = "Gloiath National Bank Services";
    Scope.Button1 = "Get all Rates";
    Scope.Button2 = "Get all transactions";
    Scope.Button3 = "Get transactions sum";
    Scope.SKUAlert = "The SKU id must have " + Scope.NUM_CHAR + " characters!";
    Scope.SKULabel = "Type a valid SKU: ";
    // TEXTS END

    // VAR
    Scope.skuValue = "";
    Scope.skuResult = "?";
    Scope.rateValue = "?";
    Scope.transValue = "?";
    // END VAR

    // EVENTS
    Scope.GetRatesClickEvent = function(context)
    {
        Http.get(Scope.URI_RATES)
            .success(function (data) {
                Scope.rateValue = data;
            })
            .error(function (data, status) {
            });
    }

    Scope.GetTransClickEvent = function (context)
    {
        Http.get(Scope.URI_TRANS)
            .success(function (data) {
                Scope.transValue = data;
            })
            .error(function (data, status) {
            });
    }

    Scope.GetTransSumClickEvent = function (context, value)
    {
        if (Scope.skuValue.length == Scope.NUM_CHAR)
        {
            Http.get(Scope.URI_TRANS + "?skuId=" + Scope.skuValue)
                .success(function (data) {
                    Scope.skuResult = data;
                })
                .error(function (data, status) {
                });
        }
    }
    // EVENTS END
}]);