app.controller("DepartmentsController", ["$scope", "$http",
    function ($scope, $http) {

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        });

    }
]);