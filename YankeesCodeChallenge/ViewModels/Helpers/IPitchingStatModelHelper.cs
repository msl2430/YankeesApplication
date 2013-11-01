namespace YankeesCodeChallenge.ViewModels.Helpers
{
    public interface IPitchingStatModelHelper
    {
        int Year { get; }
        int Games { get; }
        int GamesStarted { get; }
        string WinsLossesSaves { get; }
        string InningsPitched { get; }
        int Hits { get; }
        int StrikeOuts { get; }
        int Outs { get; }
        int Walks { get; }
        string ERA { get; }
    }
}