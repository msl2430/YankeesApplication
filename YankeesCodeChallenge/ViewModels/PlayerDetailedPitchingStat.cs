using System;
using YankeesCodeChallenge.Models.DataObjects;

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
            Year = stat.YearId;
            Games = stat.Games;
            GamesStarted = stat.GamesStarted;
            WinsLossesSaves = string.Format("{0} - {1} - {2}", stat.Wins, stat.Losses, stat.Saves);
            InningsPitched = ((stat.Outs/3.0) + (stat.Outs%3)/10.0).ToString("0.00");
            Hits = stat.Singles + stat.Doubles + stat.Triples + stat.HomeRuns;
            StrikeOuts = stat.StrikeOuts;
            Outs = stat.Outs;
            Walks = stat.IntentionalWalks + stat.UnintentionalWalks;
            ERA = ((stat.EarnedRuns*27.0)/Convert.ToDouble(stat.Outs)).ToString("0.00");
        }
    }
}