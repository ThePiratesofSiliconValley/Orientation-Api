app.controller("TrainingProgramEditController", ["$scope", "$http", "$routeParams", "$location",
    function ($scope, $http, $routeParams, $location) {

        $scope.message = "Training Program Edit Page";

        $scope.training = {};

        var getSingleTraining = function () {
            $http.get(`api/trainings/${$routeParams.id}`).then(function (result) {
                result.data.StartDay = new Date(result.data.StartDay);
                result.data.EndDay = new Date(result.data.EndDay);

                $scope.training = result.data;
            });
        };

        getSingleTraining();

        //function updateTraining() {
        //    $http.get(`api/trainings/${$routeParams.id}`).then(function (result) {
        //        $scope.training = result.data;
        //    }).catch(function (error) {
        //        console.log("error in updateTraining", error);
        //    });
        //}

        //updateTraining();

        //$scope.updateTraining = (inputData) => {
        //    var editTraining = editTrainingObject(inputData);
        //    postEditedTraining(editTraining).then(() => {
        //        $location.path("/trainings");
        //    }).catch((error) => {
        //        console.log("error in updateTraining", error);
        //    });
        //};

        //var editTrainingObject = (training) => {
        //    return {
        //        "trainingName": training.trainingName,
        //        "startDay": training.startDay,
        //        "endDay": training.endDay,
        //        "maxAttendees": training.maxAttendees,
        //        "details": training.details,
        //        "employeesAttending": training.employeesAttending
        //    };
        //};

        var postEditedTraining = (training) => {
            return $http.put("api/trainings", JSON.stringify(training));
        };

    }
]);