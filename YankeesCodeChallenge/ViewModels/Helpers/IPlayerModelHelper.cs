namespace YankeesCodeChallenge.ViewModels.Helpers
{
    public interface IPlayerModelHelper
    {
        string FullName { get; }
        string Number { get; }
        string Position { get; }
        string Team { get; }
        string TeamAbbreviation { get; }
        string League { get; }
        string BirthDate { get; }
        string BirthLocation { get; }
        string Height { get; }
        string Weight { get; }
        string Bats { get; }
        string Throws { get; }
        string HeadshotImageTag { get; }
        string HeadshotUrl { get; }
    }
}