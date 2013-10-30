using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerSummary : BasicPlayerModel
    {
        public PlayerSummary(Player player, int playerId = 0)
        {
            InitializeBasicModel(player);
            if (playerId > 0)
                base.HeadshotImage = string.Format("<img src=\"{0}\" data-playerId=\"{1}\"/>", HeadshotImage, playerId);
        }
    }
}