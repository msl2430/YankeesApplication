using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerBioDetailed : PlayerBioModel
    {
        public PlayerBioDetailed(Player player)
        {
            var playerHelper = new PlayerModelHelper(player);
            Initialize(playerHelper);
            Team = playerHelper.Team;
        }
    }
}