app.controller("DepartmentDetailsController", ["$scope", "$http", "$routeParams", function ($scope, $http, $routeParams) {

    $scope.department = {};

    $http.getSingleDepartment("/departmentdetails/:id").then(function (result) {
        $scope.department = result.data;
    });


}]);