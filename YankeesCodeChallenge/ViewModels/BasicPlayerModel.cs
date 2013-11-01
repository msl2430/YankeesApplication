using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public abstract class BasicPlayerModel : IBasicPlayerModel
    {
        public string HeadshotImage { get; internal set; }

        public string FullName { get; internal set; }

        public string Number { get; internal set; }

        public string Position { get; internal set; }

        public string Team { get; internal set; }

        public string League { get; internal set; }

        protected abstract void Initialize(PlayerModelHelper player);
    }
}