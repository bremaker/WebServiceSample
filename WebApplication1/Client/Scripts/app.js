var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(function ($routeProvider) {

    $routeProvider

        .when('/', {
            templateUrl: 'Client/Pages/homePage.html',
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
    Scope.Result = "Result = ";
    Scope.Error = "ERROR: ";
    Scope.ErrorMessage = "Incorrect data entry";
    Scope.Unknown = "?";
    // TEXTS END

    // VAR
    Scope.skuValue = "";
    Scope.skuResult = Scope.Unknown;
    Scope.rateValue = Scope.Unknown;
    Scope.transValue = Scope.Unknown;
    Scope.skuResultSum = Scope.Unknown;
    Scope.skuResultData = "";
    // END VAR

    // EVENTS
    Scope.GetRatesClickEvent = function(context)
    {
        Http.get(Scope.URI_RATES)
            .success(function (data) {
                Scope.rateValue = data;
            })
            .error(function (data, status) {
                Scope.rateValue = Scope.Error + data;
            });
    }

    Scope.GetTransClickEvent = function (context)
    {
        Http.get(Scope.URI_TRANS)
            .success(function (data) {
                Scope.transValue = data;
            })
            .error(function (data, status) {
                Scope.transValue = Scope.Error + data;
            });
    }

    Scope.GetTransSumClickEvent = function (context, value)
    {
        if (Scope.skuValue.length == Scope.NUM_CHAR)
        {
            Http.get(Scope.URI_TRANS + "?skuId=" + Scope.skuValue)
                .success(function (data) {
                    Scope.skuResultData = data.list;
                    Scope.skuResultSum = data.sum;
                })
                .error(function (data, status) {
                    Scope.skuResultData = Scope.Error + data;
                    Scope.skuResultSum = 0;
                });
        }
        else
        {
            Scope.skuResultData = Scope.Error + Scope.ErrorMessage;
            Scope.skuResultSum = 0;
        }
    }
    // EVENTS END
}]);