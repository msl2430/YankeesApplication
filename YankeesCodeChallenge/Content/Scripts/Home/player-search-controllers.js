function PlayerSummaryCtrl($scope, teamIdListModal) {
    $("#close-team-popup").click(function () { $("#teamSelectPopup").popup('close'); });
    $scope.oLanguage = { sSearch: "Search by player name" };
    $scope.columns = [
        { "sWidth": "7%",  "sClass": "center-align" },
        { "sWidth": "37%", "sClass": "padding-cell-left" },
        { "sWidth": "5%",  "sClass": "center-align" },
        { "sWidth": "13%", "sClass": "center-align" },
        { "sWidth": "25%", "sClass": "padding-cell-left" },
        { "sWidth": "12%", "sClass": "padding-cell-left" }
    ];
    $scope.columnDefs = [
        { "bSortable": false, "aTargets": [0, 2] },
        { "bSearchable": true, "aTargets": [1] }
    ];
    $scope.callbackFunction = function () {
        $.each($("#player-search-table tr").filter(function (index) {
            return index != 0
        }), function () {
            $(this).click(function (e) {
                var id = $(this).find("td").eq(0).find("img").attr('data-playerId');
                location.href = playerBioUrl + "?playerId=" + id;
            });
        });
    };

    $scope.teamIdList = '';
    $scope.$on('teamIdListModal::updatedTeamIdList', function (event) {
        $scope.teamIdList = teamIdListModal.teamIdList.join(',');
        $("#player-search-table").dataTable().fnDraw();
    });
}

function TeamListCtrl($scope, teamListModel, teamIdListModal) {
    teamListModel.getTeamListModel().then(function (data) {
        var teamList = data;
        $scope.americanLeagueList = [];
        $scope.nationalLeagueList = [];
        for (var idx in teamList) {
            if (teamList[idx].LeagueId == 1) {
                $scope.americanLeagueList.push(teamList[idx]);
            } else {
                $scope.nationalLeagueList.push(teamList[idx]);
            }
        }
    });
    
    $scope.teamSelected = function (teamId) {        
        teamIdListModal.updateTeamFilterList(teamId);
    };
}