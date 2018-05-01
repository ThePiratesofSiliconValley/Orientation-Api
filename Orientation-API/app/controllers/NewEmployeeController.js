app.controller("NewEmployeeController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    $scope.newEmployee = {};
    $scope.departments = {};

    

    $scope.selectDepartment = function (department) {
        $scope.newEmployee.departmentName = department.departmentName;
    };
    
    $http.get("/api/departments").then(function (results) {
        $scope.departments = results.data;
    });

    var createNewEmployee = function (newEmployee) {
        return $http.post("/api/employees", newEmployee);
    };

    $scope.submitNewEmployee = function (newEmployee) {
        createNewEmployee(newEmployee).then(function () {
            $location.path("/employees");
        }).catch(function (error) {
            console.log(error);
        });
    }
}]);