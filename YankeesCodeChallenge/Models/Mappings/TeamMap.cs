using FluentNHibernate.Mapping;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.Models.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            ReadOnly();

            Schema("dbo");
            Table("teams");

            Id(t => t.TeamId);

            Map(t => t.City);
            Map(t => t.Name);
            Map(t => t.Abbreviation, "abbr");
            Map(t => t.LeagueId);
        }
    }
}