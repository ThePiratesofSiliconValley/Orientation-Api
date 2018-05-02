app.controller("EmployeesDetailsController", ["$scope", "$http", "$location","$routeParams", function ($scope, $http, $location, $routeParams) {
    $scope.employee = {};
    $scope.message = "Current Employee";
    
    $http.get(`/api/employees/detail/${$routeParams.id}`).then(function (result) {
        $scope.editEmployee = result.data;
    });

    $scope.employeeEdit = function () {
        $location.path(`/editemployee/${$routeParams.id}`);
    };
}]);