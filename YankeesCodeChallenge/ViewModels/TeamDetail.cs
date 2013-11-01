using System;
using YankeesCodeChallenge.Configuration;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class TeamDetail : ITeamDetail
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public TeamDetail(Team team)
        {
            TeamId = team.TeamId;
            Name = string.Concat(team.City, " ", team.Name);
            LeagueId = Convert.ToInt32(team.LeagueId);
            LeagueName = (team.LeagueId != null || Enum.IsDefined(typeof(Constants.League), (int)team.LeagueId)) ? string.Format("{0} League", Enum.GetName(typeof (Constants.League), team.LeagueId)) : "N/A";
        }
    }
}