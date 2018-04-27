app.controller("ComputersController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    var getAllComputers = function () {
        $http.get("/api/computers").then(function (result) {
            $scope.computers = result.data;
        });
    }

    $scope.createComputer = function () {
        $location.path("/newcomputer");
    };

    $scope.deleteComputer = function (id) {
        $http.delete(`api/computers/${id}`).then(function () {
            getAllComputers();
        }).catch(function (error) {
            console.log(error);
        });
    }

    getAllComputers();
}]);