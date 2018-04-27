var app = angular.module("Orientation-API", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/",
            {
                templateUrl: "/app/partials/index.html",
                controller: "HomeController"
            })
        .when("/departments",
            {
                templateUrl: "/app/partials/departments.html",
                controller: "DepartmentsController"
            })
        .when("/computers",
            {
                templateUrl: "/app/partials/computers.html",
                controller: "ComputersController"
            })
        .when("/trainings",
            {
                templateUrl: "/app/partials/trainingPrograms.html",
                controller: "TrainingProgramController"
            })
        .when("/trainings/new",
            {
                templateUrl: "/app/partials/createTraining.html",
                controller: "CreateTrainingController"
            });
}]);