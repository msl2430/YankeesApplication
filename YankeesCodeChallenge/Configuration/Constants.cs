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
                    new IdNamePair((int)PositionTypes.Unknown, "Unknown"),
                    new IdNamePair((int)PositionTypes.Pitcher, "Pitcher"),
                    new IdNamePair((int)PositionTypes.Catcher, "Catcher"),
                    new IdNamePair((int)PositionTypes.FirstBase, "First Base"),
                    new IdNamePair((int)PositionTypes.SecondBase, "Second Base"),
                    new IdNamePair((int)PositionTypes.ThirdBase, "Third Base"),
                    new IdNamePair((int)PositionTypes.Shortstop, "Shortstop"),
                    new IdNamePair((int)PositionTypes.LeftField, "Left Field"),
                    new IdNamePair((int)PositionTypes.CenterField, "Center Field"),
                    new IdNamePair((int)PositionTypes.RightField, "Right Field"),
                    new IdNamePair((int)PositionTypes.DesignatedHitter, "Designated Hitter"),
                    new IdNamePair((int)PositionTypes.StartingPitcher, "Starting Pitcher"),
                    new IdNamePair((int)PositionTypes.ReliefPitcher, "Relief Pitcher")
                };
        }
    }
}