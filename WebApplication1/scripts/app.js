var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(function ($routeProvider) {

    $routeProvider

    .when('/', {
        templateUrl: 'pages/homePage.html',
        controller: 'mainController'
    })

    .when('/second', {
        templateUrl: 'pages/secondPage.html',
        controller: 'secondController'
    })

    .when('/second/:num', {
        templateUrl: 'pages/secondPage.html',
        controller: 'secondController'
    })

});

myApp.service('nameService', function ()
{
    this.text = "This is a service !!!!!";
});

myApp.controller('mainController', ['$scope', '$log', '$timeout','$filter','$http','$location','nameService', function (Scope, Log, Timer, Filter, Http, Location, Service)
{
    Scope.NUM_CHAR = 5;
    Scope.handle = "";
    Scope.handle2 = "Doing nothing";
    Scope.URI_BASE = 'api/products'
    Scope.timer = null;

    // Sample 1
    Scope.Name = "Rub\u00E9n";
    Timer
    (
        function ()
        {
            Scope.Name = 'RUBEN!!!!';
            Log.warn("It's time !!!!");
        },
        5000
    );

    // Sample 2
    Scope.translation = function ()
    {
        return Filter('lowercase')(Scope.handle);
    }

    // Sample 3
    Scope.rules =
    [
        { Id: 1, Title: 'Must have more than ' + Scope.NUM_CHAR + ' characters' },
        { Id: 2, Title: 'Must say something with sense' },
        { Id: 3, Title: 'Must be cool' }
    ]

    // Sample 4
    Scope.OnClickEvent = function(context, text)
    {
        context.Name = "Rub\u00E9n Brea";
        alert("Clicked: " + text);
    }

    // Sample 5: appSecond.js 

    // Sample 6
    Log.info(Location.path());

    // Sample 7
    Log.debug(Service.text);

    // Sample 8
    Scope.$watch('handle', function()
    {
        Scope.handle2 = 'Typing';

        if (Scope.timer !== null)
        {
            Timer.cancel(Scope.timer);
        }

        Scope.timer = Timer
        (
            function ()
            {
                Scope.handle2 = "Doing nothing";
            },
            1000
        );
    });
}]);