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
        .when("/newcomputer",
        {
            templateUrl: "/app/partials/newcomputer.html",
            controller: "NewComputerController"
        })
        .when("/employees",
        {
            templateUrl: "/app/partials/employees.html",
            controller: "EmployeesController"
        })
        .when("/employees/detail/:id",
        {
            templateUrl: "/app/partials/employeeDetails.html",
            controller: "EmployeesDetailsController",
        })
        .when("/create-department",
        {
            templateUrl: "/app/partials/create-department.html",
            controller: "CreateDepartmentController"
        })
        .when("/newemployee",
        {
            templateUrl: "/app/partials/newemployee.html",
            controller: "NewEmployeeController"
        })
        .when("/deletecomputer/:id",
        {
            templateUrl: "/app/partials/deletecomputer.html",
            controller: "DeleteComputerController"
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
        })
        .when("/editemployee/:id",
        {
            templateUrl: "/app/partials/editemployee.html",
            controller: "EditEmployeeController"
        })
        .when("/trainings/details/:id",
        {
            templateUrl: "/app/partials/TrainingProgramDetails.html",
            controller: "TrainingProgramDetailsController"
        })
        .when("/trainings/edit/:id",
        {
            templateUrl: "/app/partials/TrainingProgramEdit.html",
            controller: "TrainingProgramEditController"
        });

}]);