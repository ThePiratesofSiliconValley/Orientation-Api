﻿app.controller("TrainingProgramController", ["$scope", "$http", "$location",
    function($scope, $http, $location) {

        $scope.message = "This is the training page";

        $http.get("/api/trainings").then(function(result) {
            $scope.trainings = result.data;
      
        });

        $scope.createTraining = (trainingId) => {
            $location.path("trainings/new");
        };

        $scope.viewTrainingDetails = (trainingId) => {
            $location.path(`trainings/details/${trainingId}`);
        };

        $scope.deleteTraining = (trainingId) => {
            $location.path(`trainings/delete/${trainingId}`);
        };
    }
]);

