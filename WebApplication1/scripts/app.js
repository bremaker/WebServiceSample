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
    Scope.URI_BASE = 'api/rates';
    // END VALUES

    // TEXTS
    Scope.Title = "Gloiath National Bank Services";
    Scope.Button1 = "Get all Rates";
    Scope.Button2 = "Get all transactions";
    Scope.Button3 = "Get transactions sum";
    Scope.SKUAlert = "The SKU id must have " + Scope.NUM_CHAR + " characters !";
    Scope.SKULabel = "Type a valid SKU: ";
    // TEXTS END

    // VAR
    Scope.skuValue = "";
    // END VAR

    // EVENTS
    Scope.GetRatesClickEvent = function(context)
    {
        alert("Clicked: GetRatesClickEvent");

        Http.get(Scope.URI_BASE)
            .success(function (data) {
            })
            .error(function (data, status) {
            });
    }

    Scope.GetTransClickEvent = function (context)
    {
        alert("Clicked: GetTransClickEvent");
    }

    Scope.GetTransSumClickEvent = function (context, value)
    {
        alert("Clicked: GetTransSumClickEvent: " + value);
    }
    // EVENTS END
}]);