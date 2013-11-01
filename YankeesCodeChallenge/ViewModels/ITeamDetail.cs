namespace YankeesCodeChallenge.ViewModels
{
    public interface ITeamDetail
    {
        int TeamId { get; set; }
        string Name { get; set; }
        int LeagueId { get; set; }
        string LeagueName { get; set; }
    }
}