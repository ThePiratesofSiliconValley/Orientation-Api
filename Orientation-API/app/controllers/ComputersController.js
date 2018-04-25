﻿app.controller("ComputersController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $http.get("/api/computers").then(function (result) {
        $scope.computers = result.data;
    });

    var createComputer = function () {
        $location.path("/newcomputer");
    };

}]);