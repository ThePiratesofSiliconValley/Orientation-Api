app.controller("ComputersController", ["$scope", "$http", function ($scope, $http) {
    $http.get("/api/computers").then(function (result) {
        $scope.computers = result.data;
    });
}]);