app.controller("TrainingProgramDetailsController", ["$scope", "$http", "$routeParams", "$location",
    function ($scope, $http, $routeParams, $location) {

        $scope.message = "Training Program Details Page";

        $scope.training = {};

        function getTraining() {
            $http.get(`api/trainings/${$routeParams.id}`).then(function (result) {
                $scope.training = result.data;
            }).catch(function (error) {
                console.log("error in training program details", error);
            });
        }

        getTraining();

        $scope.editTrainingProgram = (trainingId) => {
            $location.path(`trainings/edit/${trainingId}`);
        };

        $scope.employees = {};

        function getEmployees() {
            $http.get(`api/employees/${$routeParams.id}`).then(function (result) {
                $scope.employees = result.data;
            }).catch(function (error) {
                console.log("error in training program details getEmployees", error);
            });
        }

        getEmployees();

    }
]);