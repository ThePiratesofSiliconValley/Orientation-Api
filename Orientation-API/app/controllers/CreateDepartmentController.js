app.controller("CreateDepartmentController", ["$scope", "$http",
    function ($scope, $http) {

        function createDepartmentsObject(department) {

        }

        $http.post("/api/departments").then(function (result) {
            $scope.departments = result.data;
        });

        //$http.post("/api/departments", { "DepartmentName": "Training" }).then(function (data) {
        //    console.log("success");
        //    console.log(data);
        //});

    }
]);