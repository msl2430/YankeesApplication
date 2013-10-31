using System.Collections.Generic;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Services
{
    public interface IPlayerService
    {
        ResultsWithCount<PlayerSearchSummary> FindPlayerSummaryBySearchString(string search, int start, int max, string teamIdFilterList, int sortColIndex = -1, string sortDirection = "");
        ResultsWithCount<PlayerSearchSummaryMobile> FindPlayerSummaryBySearchStringMobile(string search, int start, int max, string teamIdFilterList, int sortColIndex = -1, string sortDirection = "");
        IList<PlayerDetailedBattingStat> FindDetailedBattingStatistics(int playerId, int startYear, int endYear);
        IList<PlayerDetailedPitchingStat> FindDetailedPitchingStatistics(int playerId, int startYear, int endYear);
        PlayerBio FindPlayerBioByPlayerId(int playerId);
        Player FindPlayerByPlayerId(int playerId);
    }
}
