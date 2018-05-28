app.controller("EditEmployeeController", ["$scope", "$location", "$http", "$routeParams", "$filter", function ($scope, $location, $http, $routeParams, $filter) {

    var createJson = function (employee) {
        return {
            "FirstName": employee.FirstName,
            "LastName": employee.LastName,
            "DepartmentId": employee.DepartmentId,
            "ComputerId": employee.ComputerId
        };
    };

    $http.get(`/api/employees/detail/${$routeParams.id}`).then(function (results) {
        $scope.employeeDetail = results.data;
    });


    $http.get(`api/computers`).then(function (results) {
        $scope.unassignedComputers = results.data;
    });

    $http.get("/api/departments").then(function (results) {
        $scope.departments = results.data;
    });

    $scope.editEmployee = function (employee) {
        console.log("this works");
        var package = createJson(employee);
        $http.put(`api/employees/${$scope.employeeDetail.EmployeeId}`, JSON.stringify(package)).then(function (results) {
            $location.path("/employees");
        });
    };

    

}]);