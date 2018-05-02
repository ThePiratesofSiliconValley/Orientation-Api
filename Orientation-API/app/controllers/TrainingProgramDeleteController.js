app.controller("TrainingProgramDeleteController", ["$scope", "$http", "$routeParams", "$location",
    function ($scope, $http, $routeParams, $location) {

        $scope.message = "Training Program Delete Page";

        $scope.training = {};

        function getTraining() {
            $http.get(`api/trainings/${$routeParams.id}`).then(function (result) {
                $scope.training = result.data;
            }).catch(function (error) {
                console.log("error in training program details", error);
            });
        }

        getTraining();

        $scope.deleteTrainingProgram = function () {
            $http.delete(`api/trainings/${$routeParams.id}`).then(function () {
                $location.path("/trainings");
            }).catch(function (error) {
                console.log("error in deleteTrainingProgram", error);
            });
        };

        $scope.nevermindDoNotDelete = () => {
            $location.path("/trainings");
        };

    }
]);