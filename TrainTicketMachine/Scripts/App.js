var trainStationApp = angular.module('trainStationsStore', []);
var alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' '];

trainStationApp.factory("TrainStationDataService", function ($http, $q) {
    var availableStations = [];
    var nextPossibleCharacters = [];

    var read = function (filter) {
        var deferred = $q.defer();
        deferred.resolve($http({
            method: 'GET',
            url: 'api/Stations?filter="' + filter + '"'
        }));
        return deferred.promise;
    };
    return {
        AvailableStations: availableStations,
        NextPossibleCharacters: nextPossibleCharacters,
        FilterStations: read
    };
});

trainStationApp.controller('MainCtrl', function ($scope, TrainStationDataService) {
    $scope.AvailableStations = [];
    $scope.KeyboardButtons = [];
    $scope.SearchFilter = '';

    $(alphabet).each(function (index, obj) {
        $scope.KeyboardButtons.push(new KeyboardButton(obj, false, false));
    });
    $scope.KeyboardButtons.push(new KeyboardButton("<<", false, true));

    //Get Stations starting with name   
    $scope.FilterStationsByName = function (name) {
        TrainStationDataService.FilterStations(name).
            then(function (config, data, headers, status) {
                $scope.AvailableStations = arguments[0].data.Stations;
                $scope.NextPossibleCharacters = arguments[0].data.NextPossibleCharacters;
                processBtns($scope);
            }, function (reason) {
                alert('Failed: ' + reason);
            });
    };

    $scope.KeyboardButtonClick = function (t) {
        if (t.IsBackspace) {
            $scope.SearchFilter = $scope.SearchFilter.substring(0, $scope.SearchFilter.length - 1);
        } else {
            $scope.SearchFilter = $scope.SearchFilter + t.Text;
        }
    }

    $scope.$watch("SearchFilter", function (newValue, oldValue) {
        $scope.FilterStationsByName(newValue);
    });
    $scope.FilterStationsByName("");
    function processBtns(scope) {
        $(scope.KeyboardButtons).each(function (index, obj) {
            var found = false;
            var btn = obj;
            if (btn.IsBackspace && scope.SearchFilter.length > 0) {
                found = true;
            } else {
                $(scope.NextPossibleCharacters).each(function (i, t) {
                    if (btn.Text == t) {
                        found = true;
                        return;
                    }
                });
            }
            btn.IsDisabled = !found;
        });
    }
});

