app.controller("CreateTrainingController", function ($scope, $http, $location) {
        $scope.trainings = {};

        $scope.addTraining = (inputData) => {
            var newTraining = createTrainingObject(inputData);
            postNewTraining(newTraining).then(() => {
                $location.path("/trainings");
            }).catch((err) => {
                console.log("error in postNewContact", err);
            });
        };

        var createTrainingObject = (training) => {
            return {
                "trainingName": training.trainingName,
                "startDay": training.startDay,
                "endDay": training.endDay,
                "maxAttendees": training.maxAttendees
            };
        }

        var postNewTraining = (training) => {
            return $http.post("api/trainings", JSON.stringify(training));

        };
    }
);