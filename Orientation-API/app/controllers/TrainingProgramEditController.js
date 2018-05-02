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

        $scope.updateTrainingProgram = function () {
            $http.put(`api/trainings/${$routeParams.id}`, $scope.training).then(function () {
                $location.path("/trainings");
            }).catch(function (error) {
                console.log("error in updateTrainingPrograms", error);
            });
        };

    }
]);