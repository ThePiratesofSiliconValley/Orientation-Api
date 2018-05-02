app.controller("EmployeesController", ["$scope", "$http", "$location", function($scope, $http, $location){

    $scope.message = "Current Employees";

    $http.get("/api/employees").then(function (result) {
        $scope.employees = result.data;
    });


    $scope.employeeDetails = (employeeId) => {
        $location.path(`/employees/${employeeId}`);
    };
    $scope.AddNewEmployee = function () {
        $location.path("/newemployee")
    };


}]);