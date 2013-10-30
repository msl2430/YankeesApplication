YankeesApp
    .factory('detailedBattingStatsModel', function ($http) {
        var detailedBattingStatsModel = {
            getDetailedBattingStatsModel: function (playerId) {
                var promise = $http.get(baseUrl + 'Api/PlayerDetailedBattingStat?playerId=' + playerId).then(function (response) {
                    return response.data;
                });
                return promise;
            }
        };
        return detailedBattingStatsModel;
    })
    .factory('detailedPitchingStatsModel', function ($http) {
        var detailedPitchingStatsModel = {
            getDetailedPitchingStatsModel: function (playerId) {
                var promise = $http.get(baseUrl + 'Api/PlayerDetailedPitchingStat?playerId=' + playerId).then(function (response) {
                    return response.data;
                });
                return promise;
            }
        };
        return detailedPitchingStatsModel;
    })
    .factory('playerBioModel', function($http) {
        var playerBioModel = {
            getPlayerBioModel: function(playerId) {
                var promise = $http.get(baseUrl + 'Api/PlayerBio?playerId=' + playerId).then(function(response) {
                    return response.data;
                });
                return promise;
            }
        };
        return playerBioModel;
    });