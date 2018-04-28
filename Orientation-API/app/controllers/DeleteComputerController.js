app.controller("DeleteComputerController", ["$routeParams", "$http", "$location", "$scope", function ($routeParams, $http, $location, $scope) {

    $scope.delete = function () {
        $http.delete(`api/computers/${$routeParams.id}`).then(function () {
            $location.path("/computers");
        }).catch(function (error) {
            console.log(error);
        });
    };

    $scope.noDelete = function () {
        $location.path("/computers");
    };

}]);