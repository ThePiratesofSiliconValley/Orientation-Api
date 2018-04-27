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
        .when("/create-department",
        {
            templateUrl: "/app/partials/create-department.html",
            controller: "CreateDepartmentController"
        });
}]);