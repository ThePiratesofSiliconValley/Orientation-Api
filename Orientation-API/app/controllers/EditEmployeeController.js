﻿app.controller("EditEmployeeController", ["$scope", "$location", "$http", "$routeParams", "$filter", function ($scope, $location, $http, $routeParams, $filter) {

    var createJson = function (employee) {
        return {
            "FirstName": employee.FirstName,
            "LastName": employee.LastName,
            "DepartmentId": employee.DepartmentId,
            "SeparationDate": employee.SeparationDate,
            "ComputerId": employee.ComputerId

        };
    };

    $http.get(`/api/employees/detail/${$routeParams.id}`).then(function (results) {
        $scope.employeeDetail = results.data;
        $scope.employeeDetail.SeparationDate = Date.parse($scope.employeeDetail.SeparationDate);
        console.log($scope.employeeDetail);
    });


    $http.get(`api/computers/${$routeParams.id}/unassigned`).then(function (results) {
        $scope.unassignedComputers = results.data;
    });

    $http.get("/api/departments").then(function (results) {
        $scope.departments = results.data;
    });

    $scope.editEmployee = function (employee) {
        console.log("this works");
        var package = createJson(employee);
        console.log(package);
    };

    

}]);