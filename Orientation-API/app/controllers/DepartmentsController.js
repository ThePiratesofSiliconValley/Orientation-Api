app.controller("DepartmentsController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "This is the Departments page";

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        });

        $scope.viewDepartmentDetails = function (departmentId) {
            $location.path(`/departmentdetails/${departmentId}`);
        };

    }
]);