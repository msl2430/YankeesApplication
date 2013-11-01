using FluentNHibernate.Mapping;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.Models.Mappings
{
    public class BattingStatMap : ClassMap<BattingStat>
    {
        public BattingStatMap()
        {
            ReadOnly();

            Schema("dbo");
            Table("battingstats");

            CompositeId()
                .KeyProperty(p => p.PlayerId)
                .KeyProperty(p => p.YearId);
            
            Map(bs => bs.Games, "g");
            Map(bs => bs.AtBats, "ab");
            Map(bs => bs.Singles, "b1");
            Map(bs => bs.Doubles, "b2");
            Map(bs => bs.Triples, "b3");
            Map(bs => bs.HomeRuns, "hr");
            Map(bs => bs.UnintentionalWalks, "ubb");
            Map(bs => bs.HitByPitches, "hbp");
            Map(bs => bs.StrikeOuts, "so");
            Map(bs => bs.IntentionalWalks, "ibb");
            Map(bs => bs.SacrificeHits, "sh");
            Map(bs => bs.SacrificeFlies, "sf");
            Map(bs => bs.StolenBases, "sb");
            Map(bs => bs.CaughtStealing, "cs");
            Map(bs => bs.PlateAppearances, "pa");
            Map(bs => bs.Runs, "r");
            Map(bs => bs.RunsBattedIn, "rbi");
            Map(bs => bs.ParkFactor, "pf");
            Map(bs => bs.GroundBalls, "gb");
            Map(bs => bs.FlyBalls, "fb");
            Map(bs => bs.Pops, "pop");
            Map(bs => bs.LineDrives, "ld");
            Map(bs => bs.Bunts, "bunt");
        }
    }
}