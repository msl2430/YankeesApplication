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

        public static class Position
        {
            public static readonly IList<IdNamePair> Positions = new List<IdNamePair>()
                {
                    new IdNamePair(0, "Unknown"),
                    new IdNamePair(1, "Pitcher"),
                    new IdNamePair(2, "Catcher"),
                    new IdNamePair(3, "First Base"),
                    new IdNamePair(4, "Second Base"),
                    new IdNamePair(5, "Third Base"),
                    new IdNamePair(6, "Shortstop"),
                    new IdNamePair(7, "Left Field"),
                    new IdNamePair(8, "Center Field"),
                    new IdNamePair(9, "Right Field"),
                    new IdNamePair(10, "Designated Hitter"),
                    new IdNamePair(11, "Starting Pitcher"),
                    new IdNamePair(12, "Relief Pitcher")
                };
        }
    }
}