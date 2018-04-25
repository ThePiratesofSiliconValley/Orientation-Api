var app = angular.module("Orientation-API", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "/app/partials/index.html",
            controller: "HomeController"
        })
        .when("/departments",
        {
            templateUrl: "/app/partials/departments.html",
            controller: "DepartmentsController"
        })
        .when("/computers",
        {
            templateUrl: "/app/partials/computers.html",
            controller: "ComputersController"
        });
}]);