app.controller("TrainingProgramController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "This is the training page";

        $http.get("/api/trainings").then(function (result) {
            $scope.trainings = result.data;
        });

        $scope.createTraining = (trainingId) => {
            $location.path("trainings/new");
        }; 

        //$scope.addContact = (inputData) => {
        //    inputData.uid = $rootScope.uid;
        //    inputData.favorite = false;
        //    let newContact = ContactService.createContactObject(inputData);
        //    ContactService.postNewContact(newContact).then(() => {
        //        $location.path('/contacts/view');
        //    }).catch((err) => {
        //        console.log("error in postNewContact", err);
        //    });
        //};

        //const createTrainingObject = (training) => {
        //    return {
        //        "trainingName": training.trainingID,
        //        "startDay": training.startDay,
        //        "endDay": training.endDay,
        //        "maxAttendees": training.maxAttendees,
            //};
    //    }
    }
]);