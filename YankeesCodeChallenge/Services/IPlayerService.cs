using System.Collections.Generic;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Services
{
    public interface IPlayerService
    {
        ResultsWithCount<PlayerSummary> FindPlayerSummaryBySearchString(string search, int start, int max, int sortColIndex = -1, string sortDirection = "");
        IList<PlayerDetailedBattingStat> FindDetailedBattingStatistics(int playerId, int startYear, int endYear);
        IList<PlayerDetailedPitchingStat> FindDetailedPitchingStatistics(int playerId, int startYear, int endYear);
        PlayerBio FindPlayerBioByPlayerId(int playerId);
        Player FindPlayerByPlayerId(int playerId);
    }
}
