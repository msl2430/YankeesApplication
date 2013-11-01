using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels.Helpers
{
    public class BattingStatModelHelper : IBattingStatModelHelper
    {
        private BattingStat BattingStat { get; set; }

        public BattingStatModelHelper(BattingStat stat)
        {
            BattingStat = stat;
        }

        public int Year
        {
            get { return BattingStat.YearId; }
        }

        public int Games
        {
            get { return BattingStat.Games; }
        }

        public int AtBats
        {
            get { return BattingStat.AtBats; }
        }

        public int Hits
        {
            get { return BattingStat.Singles + BattingStat.Doubles + BattingStat.Triples + BattingStat.HomeRuns; }
        }

        public int StrikeOuts
        {
            get { return BattingStat.StrikeOuts; }
        }

        public int Walks
        {
            get { return BattingStat.IntentionalWalks + BattingStat.UnintentionalWalks; }
        }

        public string Average
        {
            get { return (Convert.ToDouble(Hits)/Convert.ToDouble(BattingStat.AtBats)).ToString(".000"); }
        }

        public string OBP
        {
            get { return (Convert.ToDouble(Hits + Walks + BattingStat.HitByPitches)/Convert.ToDouble(BattingStat.AtBats + Walks + BattingStat.HitByPitches + BattingStat.SacrificeFlies)).ToString(".000"); }
        }

        public string SLG
        {
            get { return (Convert.ToDouble(BattingStat.Singles + (2*BattingStat.Doubles) + (3*BattingStat.Triples) + (4*BattingStat.HomeRuns))/Convert.ToDouble(BattingStat.AtBats)).ToString(".000"); }
        }

        public string OPS
        {
            get { return (Convert.ToDouble(OBP) + Convert.ToDouble(SLG)).ToString(".000"); }
        }
    }
}