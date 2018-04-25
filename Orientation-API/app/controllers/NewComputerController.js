app.controller("NewComputerController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    $scope.addComputer = {};

    var createNewComputer = function (computer) {
        return $http.post("api/computers", JSON.stringify(computer));
    };

    $scope.submitForm = function () {
 
        var newComputer = {
            "computermanufacturer": $scope.addcomputer.computermanufacturer,
            "computermake": $scope.addcomputer.computermake,
            "purchasedate": $scope.addcomputer.purchasedate
        };

        createNewComputer(newComputer).then(function () {
            $location.path("/computers");
        }).catch(function (error) {
            console.log(error);
        });

    };

}]);