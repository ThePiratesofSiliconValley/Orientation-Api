app.controller("TrainingProgramEditController", ["$scope", "$http", "$routeParams", "$location",
    function ($scope, $http, $routeParams, $location) {

        $scope.message = "Training Program Edit Page";

        $scope.training = {};

        $scope.updateTraining = (inputData) => {
            var editTraining = editTrainingObject(inputData);
            postEditedTraining(editTraining).then(() => {
                $location.path("/trainings");
            }).catch((error) => {
                console.log("error in updateTraining", error);
            });
        };

        var editTrainingObject = (training) => {
            return {
                "trainingName": training.trainingName,
                "startDay": training.startDay,
                "endDay": training.endDay,
                "maxAttendees": training.maxAttendees,
                "details": training.details,
                "employeesAttending": training.employeesAttending
            };
        };

        var postEditedTraining = (training) => {
            return $http.put("api/trainings", JSON.stringify(training));
        };

    }
]);