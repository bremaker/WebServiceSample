myApp.directive('addDish', function () {
    return {
        restrict: 'AECM',
        templateUrl: 'Directives/addDish.html',
        replace: true,
        scope: 
            {
                clickHandle: '&',
                newItem: '='
            },
        transclude: true
    }
});

myApp.controller('secondController', ['$scope', '$log', '$timeout', '$filter', '$http', '$location', '$routeParams', function (Scope, Log, Timer, Filter, Http, Location, Route)
{
    Scope.num = Route.num || 1;

    Scope.NUM_CHAR = 5;
    Scope.URI_BASE = 'api/products'

    // Sample 5
    Scope.dishes = [];

    function CleanArray(array) {
        var new_array = [];

        for (var i in array) {
            if (array[i]) {
                new_array.push(array[i]);
            }
        }

        return new_array;
    }

    Scope.getAllDishes = function (num_items) {
        Http.get(Scope.URI_BASE + (num_items ? "?top=" + num_items + "&orderby=Name" : ""))
           .success(function (data) {
               Scope.dishes = CleanArray(data);
           })
           .error(function (data, status) {
               Log.info(data);
           });
    }

    Scope.getAllDishes();

    Scope.addDish = function () {
        Http.post(Scope.URI_BASE, Scope.newDish)
            .success(function (data) {
                Scope.dishes = CleanArray(data);
            })
            .error(function (data, status) {
                Log.info(data);
            });
    };

    Scope.findDish = function () {
        Http.get(Scope.URI_BASE + "/" + Scope.dishId)
            .success(function (data) {
                Scope.dish = data;
            })
            .error(function (data, status) {
                Log.info(data);
            });
    };

    Scope.deleteDish = function (id) {
        Http.delete(Scope.URI_BASE + "/" + id)
            .success(function (data) {
                Scope.getAllDishes();
            })
            .error(function (data, status) {
                Log.info(data);
            });
    };
}]);