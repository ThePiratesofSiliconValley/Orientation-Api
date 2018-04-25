app.controller("EmployeesController", ["$scope", "$http", function($scope, $http){

    $scope.message = "Current Employees";

    $http.get("/api/employees").then(function (result) {
        $scope.employees = result.data;
    });
}]);