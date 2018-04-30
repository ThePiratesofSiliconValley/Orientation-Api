app.controller("TrainingProgramDetailsController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "Training Program Details Page";

        $http.get("/api/trainings/{trainingId}").then(function (result) {
            $scope.trainings = result.data;
        });

    }
]);