using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerSearchModel : BasicPlayerModel
    {
        protected sealed override void Initialize(PlayerModelHelper playerHelper)
        {
            HeadshotImage = playerHelper.HeadshotImageTag;
            FullName = playerHelper.FullName;
            Number = playerHelper.Number;
            Position = playerHelper.Position;
            League = playerHelper.League;
            Team = playerHelper.Team;
        }
    }
}