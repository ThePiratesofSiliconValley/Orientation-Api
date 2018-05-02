app.controller("EditEmployeeController", ["$scope", "$location", "$http", "$routeParams", function ($scope, $location, $http, $routeParams) {

    $http.get(`/api/employees/detail/${routeParams.id}`).then(function (results) {
        $scope.employeeDetail = results.data;
    });


    $http.get(`api/computers/${routeParams.id}/unassigned`).then(function (result) {
        $scope.unassignedComputers = results.data;
    });

    $http.get("/api/departments").then(function (result) {
        $scope.departments = result.data;
    });

}])