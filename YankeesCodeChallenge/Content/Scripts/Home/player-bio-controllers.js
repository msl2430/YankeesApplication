function PlayerBioCtrl($scope, $location, playerBioModel) {
    $scope.playerBio = { HeadshotImage: "" };
    playerBioModel.getPlayerBioModel(parseQueryString()['playerId']).then(function (data) {
        $scope.playerBio = data;
    });
}
function LastThreeSeasonCtrl($scope, detailedBattingStatsModel, detailedPitchingStatsModel) {
    $scope.isPitcher = isPitcher;
    if (isPitcher == false) {
        detailedBattingStatsModel.getDetailedBattingStatsModel(parseQueryString()['playerId']).then(function (data) {
            $scope.playerDetailedBattingStat = data;
        });
    } else {
        detailedPitchingStatsModel.getDetailedPitchingStatsModel(parseQueryString()['playerId']).then(function (data) {
            $scope.playerDetailedPitchingStat = data;
        });
    }
}