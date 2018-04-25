app.controller("DepartmentsController", ["$scope", "$http",
    function ($scope, $http) {

        $scope.message = "This is the Departments page";

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        });

    }
]);