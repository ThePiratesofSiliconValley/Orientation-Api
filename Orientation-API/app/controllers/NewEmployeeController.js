app.controller("NewEmployeeController", ["$scope", "$http", function ($scope, $http) {

    $scope.newEmployee = {};
    $scope.departments = {};

    

    $scope.selectDepartment = function (department) {
        $scope.newEmployee.departmentName = department.departmentName;
    };
    
    $http.get("/api/departments").then(function (results) {
        $scope.departments = results.data;
    });

    $scope.createNewEmployee = function (newEmployee) {
        return $http.post("/api/employees", JSON.stringify(newEmployee));
    };

    $scope.submitNewEmployee = function (newEmployee) {
        var newEmployee = {
            "FirstName": $scope.newEmployee.FirstName,
            "LastName": $scope.newEmployee.LastName,
            "DepartmentName": $scope.newEmployee.DepartmentName
        };

        createNewEmployee(newEmployee).then(function () {
            $location.("/employees");
        }).catch(function (error) {
            console.log(error);
        });
    }
}]);