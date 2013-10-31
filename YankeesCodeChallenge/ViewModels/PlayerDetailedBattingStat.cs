using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerDetailedBattingStat
    {
        public int Year { get; set; }

        public int Games { get; set; }

        public int AtBats { get; set; }

        public int Hits { get; set; }

        public int StrikeOuts { get; set; }

        public int Walks { get; set; }

        public string Average { get; set; }

        public string OBP { get; set; }

        public string SLG { get; set; }

        public string OPS { get; set; }

        public PlayerDetailedBattingStat(BattingStat stat)
        {
            Year = stat.YearId;
            Games = stat.Games;
            AtBats = stat.AtBats;
            Hits = stat.Singles + stat.Doubles + stat.Triples + stat.HomeRuns;
            StrikeOuts = stat.StrikeOuts;
            Walks = stat.IntentionalWalks + stat.UnintentionalWalks;
            Average = (Convert.ToDouble(Hits) / Convert.ToDouble(stat.AtBats)).ToString(".000");
            OBP = (Convert.ToDouble(Hits + Walks + stat.HitByPitches) / Convert.ToDouble(stat.AtBats + Walks + stat.HitByPitches + stat.SacrificeFlies)).ToString(".000");
            SLG = (Convert.ToDouble(stat.Singles + (2 * stat.Doubles) + (3 * stat.Triples) + (4 * stat.HomeRuns)) / Convert.ToDouble(stat.AtBats)).ToString(".000");
            OPS = (Convert.ToDouble(OBP) + Convert.ToDouble(SLG)).ToString(".000");
        }
    }
}