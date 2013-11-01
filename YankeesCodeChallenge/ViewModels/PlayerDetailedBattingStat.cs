using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerDetailedBattingStat
    {
        public int Year { get; internal set; }

        public int Games { get; internal set; }

        public int AtBats { get; internal set; }

        public int Hits { get; internal set; }

        public int StrikeOuts { get; internal set; }

        public int Walks { get; internal set; }

        public string Average { get; internal set; }

        public string OBP { get; internal set; }

        public string SLG { get; internal set; }

        public string OPS { get; internal set; }

        public PlayerDetailedBattingStat(BattingStat stat)
        {
            var statHelper = new BattingStatModelHelper(stat);
            Year = statHelper.Year;
            Games = statHelper.Games;
            AtBats = statHelper.AtBats;
            Hits = statHelper.Hits;
            StrikeOuts = statHelper.StrikeOuts;
            Walks = statHelper.Walks;
            Average = statHelper.Average;
            OBP = statHelper.OBP;
            SLG = statHelper.SLG;
            OPS = statHelper.OPS;
        }
    }
}