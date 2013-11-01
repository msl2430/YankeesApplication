using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerSearchSummaryMobile : PlayerSearchModel
    {
        public PlayerSearchSummaryMobile(Player player)
        {
            var playerHelper = new PlayerModelHelper(player);
            Initialize(playerHelper);
            Team = playerHelper.TeamAbbreviation;
        }
    }
}