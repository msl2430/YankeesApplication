using FluentNHibernate.Mapping;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.Models.Mappings
{
    public class PitchingStatMap : ClassMap<PitchingStat>
    {
        public PitchingStatMap()
        {
            ReadOnly();

            Schema("dbo");
            Table("pitchingstats");

            CompositeId()
                .KeyProperty(ps => ps.PlayerId)
                .KeyProperty(ps => ps.YearId);

            Map(ps => ps.Games, "g");
            Map(ps => ps.GamesStarted, "gs");
            Map(ps => ps.Wins, "w");
            Map(ps => ps.Losses, "l");
            Map(ps => ps.Saves, "sv");
            Map(ps => ps.Outs, "outs");
            Map(ps => ps.AtBats, "ab");
            Map(ps => ps.Singles, "b1");
            Map(ps => ps.Doubles, "b2");
            Map(ps => ps.Triples, "b3");
            Map(ps => ps.HomeRuns, "hr");
            Map(ps => ps.UnintentionalWalks, "ubb");
            Map(ps => ps.HitByPitches, "hbp");
            Map(ps => ps.StrikeOuts, "so");
            Map(ps => ps.IntentionalWalks, "ibb");
            Map(ps => ps.SacrificeHits, "sh");
            Map(ps => ps.SacrificeFlies, "sf");
            Map(ps => ps.PlateAppearances, "pa");
            Map(ps => ps.Runs, "r");
            Map(ps => ps.GroundBalls, "gb");
            Map(ps => ps.FlyBalls, "fb");
            Map(ps => ps.Pops, "pop");
            Map(ps => ps.LineDrives, "ld");
            Map(ps => ps.Bunts, "bunt");
            Map(ps => ps.EarnedRuns, "er");
        }
    }
}