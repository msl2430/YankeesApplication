using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerSearchSummary : BasicPlayerModel
    {
        public PlayerSearchSummary(Player player)
        {
            InitializeBasicModel(player);
            base.HeadshotImage = string.Format("<img src=\"{0}\" data-playerId=\"{1}\"/>", HeadshotImage, player.PlayerId);
        }
    }
}