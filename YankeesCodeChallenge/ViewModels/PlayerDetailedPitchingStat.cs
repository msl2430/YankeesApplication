using System;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerDetailedPitchingStat
    {
        public int Year { get; set; }

        public int Games { get; set;}

        public int GamesStarted { get; set; }

        public string WinsLossesSaves { get; set; }

        public string InningsPitched { get; set; }

        public int Hits { get; set; }

        public int StrikeOuts { get; set; }

        public int Outs { get; set; }

        public int Walks { get; set; }

        public string ERA { get; set; }

        public PlayerDetailedPitchingStat(PitchingStat stat)
        {
            var statHelper = new PitchingStatModelHelper(stat);
            Year = statHelper.Year;
            Games = statHelper.Games;
            GamesStarted = statHelper.GamesStarted;
            WinsLossesSaves = statHelper.WinsLossesSaves;
            InningsPitched = statHelper.InningsPitched;
            Hits = statHelper.Hits;
            StrikeOuts = statHelper.StrikeOuts;
            Outs = statHelper.Outs;
            Walks = statHelper.Walks;
            ERA = statHelper.ERA;
        }
    }
}