using FluentNHibernate.Mapping;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.Models.Mappings
{
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            ReadOnly();

            Schema("dbo");
            Table("players");

            Id(p => p.PlayerId);

            Map(p => p.LastName);
            Map(p => p.FirstName);
            Map(p => p.Bats);
            Map(p => p.Throws);
            Map(p => p.BirthDate);
            Map(p => p.BirthCity);
            Map(p => p.BirthCountry);
            Map(p => p.BirthState);
            Map(p => p.Height);
            Map(p => p.Weight);
            Map(p => p.Position);
            Map(p => p.Number);
            Map(p => p.HeadShotUrl);

            References(p => p.Team)
                .Column("TeamId")
                .Fetch.Join()
                .Nullable();
        }
    }
}