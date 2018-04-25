app.controller("CreateDepartmentController", ["$scope", "$http",
    function ($scope, $http) {

        $scope.message = "This is the Create a Department page";

        $http.post("/api/departments").then(function (result) {
            $scope.departments = result.data;
        });

    }
]);