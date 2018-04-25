﻿var app = angular.module("Orientation-API", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/index.html",
            controller: "HomeController"
        })
        .when("/computers",
        {
            templateUrl: "/app/partials/computers.html",
            controller: "ComputersController"
        });
}]);