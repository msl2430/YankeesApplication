using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerBioSummary : PlayerBioModel
    {
        public PlayerBioSummary(Player player)
        {
            var playerHelper = new PlayerModelHelper(player);
            Initialize(playerHelper);            
        }
    }
}