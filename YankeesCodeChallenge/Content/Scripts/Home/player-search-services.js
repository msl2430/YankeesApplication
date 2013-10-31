YankeesApp
    .factory('teamListModel', function($http) {
        var teamListModel = {
            getTeamListModel: function () {
                var promise = $http.get(baseUrl + 'Api/TeamList').then(function (response) {
                    return response.data;
                });
                return promise;
            }
        };
        return teamListModel;
    })
    .service('teamIdListModal', function ($rootScope) {
        this.teamIdList = new Array();
        this.updateTeamFilterList = function (teamId) {
            var idx = $.inArray(teamId, this.teamIdList);
            if (idx == -1) {
                this.teamIdList.push(teamId);
            } else {
                this.teamIdList.splice(idx, 1);
            }
            $rootScope.$broadcast('teamIdListModal::updatedTeamIdList');
        };
    });
