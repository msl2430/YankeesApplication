using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels.Helpers
{
    public class PitchingStatModelHelper : IPitchingStatModelHelper
    {
        private PitchingStat PitchingStat { get; set; }

        public PitchingStatModelHelper(PitchingStat stat)
        {
            PitchingStat = stat;
        }

        public int Year
        {
            get { return PitchingStat.YearId; }
        }

        public int Games
        {
            get { return PitchingStat.Games; }
        }

        public int GamesStarted
        {
            get { return PitchingStat.GamesStarted; }
        }

        public string WinsLossesSaves
        {
            get { return string.Format("{0} - {1} - {2}", PitchingStat.Wins, PitchingStat.Losses, PitchingStat.Saves); }
        }

        public string InningsPitched
        {
            get { return ((PitchingStat.Outs/3.0) + (PitchingStat.Outs%3)/10.0).ToString("0.00"); }
        }

        public int Hits
        {
            get { return PitchingStat.Singles + PitchingStat.Doubles + PitchingStat.Triples + PitchingStat.HomeRuns; }
        }

        public int StrikeOuts
        {
            get { return PitchingStat.StrikeOuts; }
        }

        public int Outs
        {
            get { return PitchingStat.Outs; }
        }

        public int Walks
        {
            get { return PitchingStat.IntentionalWalks + PitchingStat.UnintentionalWalks; }
        }

        public string ERA
        {
            get { return ((PitchingStat.EarnedRuns*27.0)/Convert.ToDouble(PitchingStat.Outs)).ToString("0.00"); }
        }
    }
}