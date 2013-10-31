using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.Core;

namespace YankeesCodeChallenge.Configuration
{
    public class Constants
    {
        public enum League
        {
            American = 1,
            National
        }

        public enum Bats
        {
            Right = 1,
            Left,
            Switch
        }

        public enum Throws
        {
            Right = 1,
            Left
        }

        public enum PositionTypes
        {
            Unknown,
            Pitcher,
            Catcher,
            FirstBase,
            SecondBase,
            ThirdBase,
            Shortstop,
            LeftField,
            CenterField,
            RightField,
            DesignatedHitter,
            StartingPitcher,
            ReliefPitcher
        }

        public static class Position
        {
            public static readonly IList<IdNamePair> Positions = new List<IdNamePair>()
                {
                    new IdNamePair((int)PositionTypes.Unknown, "N/A"),
                    new IdNamePair((int)PositionTypes.Pitcher, "P"),
                    new IdNamePair((int)PositionTypes.Catcher, "C"),
                    new IdNamePair((int)PositionTypes.FirstBase, "1B"),
                    new IdNamePair((int)PositionTypes.SecondBase, "2B"),
                    new IdNamePair((int)PositionTypes.ThirdBase, "3B"),
                    new IdNamePair((int)PositionTypes.Shortstop, "SS"),
                    new IdNamePair((int)PositionTypes.LeftField, "LF"),
                    new IdNamePair((int)PositionTypes.CenterField, "CF"),
                    new IdNamePair((int)PositionTypes.RightField, "RF"),
                    new IdNamePair((int)PositionTypes.DesignatedHitter, "DH"),
                    new IdNamePair((int)PositionTypes.StartingPitcher, "P"),
                    new IdNamePair((int)PositionTypes.ReliefPitcher, "P")
                };
        }
    }
}