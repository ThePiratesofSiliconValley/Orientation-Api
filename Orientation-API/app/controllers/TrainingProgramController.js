app.controller("TrainingProgramController", ["$scope", "$http",
    function ($scope, $http) {

        $scope.message = "This is the training page";

        $http.get("/api/trainings").then(function (result) {
            $scope.trainings = result.data;
        });

        

    }
]);