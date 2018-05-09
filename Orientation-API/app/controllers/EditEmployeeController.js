app.controller("EditEmployeeController", ["$scope", "$location", "$http", "$routeParams", "$filter", function ($scope, $location, $http, $routeParams, $filter) {

    $http.get(`/api/employees/detail/${$routeParams.id}`).then(function (results) {
        $scope.employeeDetail = results.data;
        $scope.department = $scope.employeeDetail.DepartmentId;
        $scope.computer = $scope.employeeDetail.ComputerId;
        console.log($scope.employeeDetail);
    });


    $http.get(`api/computers/${$routeParams.id}/unassigned`).then(function (results) {
        $scope.unassignedComputers = results.data;
        console.log($scope.unassignedComputers);
    });

    $http.get("/api/departments").then(function (results) {
        $scope.departments = results.data;
        console.log($scope.departments);
    });

    

}]);