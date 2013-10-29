using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YankeesCodeChallenge.Models.DataObjects
{
    /// <summary>
    /// dbo.pitchingstats
    /// </summary>
    public class PitchingStat
    {
        public virtual int PlayerId { get; set; }

        public virtual int YearId { get; set; }

        public virtual int Games { get; set; }

        public virtual int GamesStarted { get; set; }

        public virtual int Wins { get; set; }

        public virtual int Losses { get; set; }

        public virtual int Saves { get; set; }

        public virtual int Outs { get; set; }

        public virtual int AtBats { get; set; }

        public virtual int Singles { get; set; }

        public virtual int Doubles { get; set; }

        public virtual int Triples { get; set; }

        public virtual int HomeRuns { get; set; }

        public virtual int UnintentionalWalks { get; set; }

        public virtual int HitByPitches { get; set; }

        public virtual int StrikeOuts { get; set; }

        public virtual int IntentionalWalks { get; set; }

        public virtual int SacrificeHits { get; set; }

        public virtual int SacrificeFlies { get; set; }

        public virtual int PlateAppearances { get; set; }

        public virtual int Runs { get; set; }

        public virtual int GroundBalls { get; set; }

        public virtual int FlyBalls { get; set; }

        public virtual int Pops { get; set; }

        public virtual int LineDrives { get; set; }

        public virtual int Bunts { get; set; }

        public virtual int EarnedRuns { get; set; }

        public override bool Equals(object obj)
        {
            var right = obj as PitchingStat;

            return right != null
                && PlayerId == right.PlayerId
                && YearId == right.YearId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}