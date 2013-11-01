using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerBioModel : BasicPlayerModel
    {
        public string BirthDate { get; internal set; }

        public string BirthLocation { get; internal set; }

        public string Height { get; internal set; }

        public string Weight { get; internal set; }

        public string Bats { get; internal set; }

        public string Throws { get; internal set; }

        protected sealed override void Initialize(PlayerModelHelper playerHelper)
        {
            HeadshotImage = playerHelper.HeadshotUrl;
            FullName = playerHelper.FullName;
            Number = playerHelper.Number;
            Position = playerHelper.Position;
            League = playerHelper.League;
            BirthDate = playerHelper.BirthDate;
            BirthLocation = playerHelper.BirthLocation;
            Height = playerHelper.Height;
            Weight = playerHelper.Weight;
            Bats = playerHelper.Bats;
            Throws = playerHelper.Throws;
            Team = playerHelper.Team;
        }
    }
}