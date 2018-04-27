app.controller("CreateDepartmentController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

        $scope.createDepartment = {};

        var createNewDepartment = function (department) {
            return $http.post("/api/departments", JSON.stringify(department));
        };

        $scope.submitForm = function () {

            var newDepartment = {
                "departmentname": $scope.adddepartment.departmentname
            };

            createNewDepartment(newDepartment).then(function () {
                $location.path("/departments");
            }).catch(function (error) {
                console.log(error);
            });

        };

    }
]);