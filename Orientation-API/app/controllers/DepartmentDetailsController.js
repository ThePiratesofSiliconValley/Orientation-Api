app.controller("DepartmentDetailsController", ["$scope", "$http", "$routeParams", function ($scope, $http, $routeParams) {

    $scope.department = {};

    $http.get(`api/departments/${$routeParams.id}`).then(function (result) {
        $scope.department = result.data;
    });


}]);