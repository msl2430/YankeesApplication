using System;
using System.Linq;
using YankeesCodeChallenge.Configuration;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels.Helpers
{
    public class PlayerModelHelper : IPlayerModelHelper
    {
        private Player Player { get; set; }

        public PlayerModelHelper(Player player)
        {
            Player = player;
        }

        public string FullName
        {
            get { return string.Concat(Player.FirstName, " ", Player.LastName); }
        }

        public string Number
        {
            get { return Player.Number == null || Player.Number == 0 ? "N/A" : Player.Number.ToString(); }
        }

        public string Position
        {
            get { return Constants.Position.Positions.Any(p => p.Id == Player.Position) ? Constants.Position.Positions.FirstOrDefault(p => p.Id == Player.Position).Name : "N/A"; }
        }

        public string Team
        {
            get { return string.Concat(Player.Team.City, " ", Player.Team.Name); }
        }

        public string TeamAbbreviation
        {
            get { return Player.Team.Abbreviation; }
        }

        public string League
        {
            get
            {
                return Player.Team.LeagueId != null
                           ? string.Concat(Enum.GetName(typeof (Constants.League), (int) Player.Team.LeagueId).Substring(0, 1), "L")
                           : "N/A";
            }
        }

        public string BirthDate
        {
            get { return Player.BirthDate != null ? Convert.ToDateTime(Player.BirthDate).ToShortDateString() : "N/A"; }
        }

        public string BirthLocation
        {
            get
            {
                if (!string.IsNullOrEmpty(string.Concat(Player.BirthCity, Player.BirthCountry, Player.BirthState)))
                {
                    return string.Format("{0}, {1}", Player.BirthCity, string.IsNullOrEmpty(Player.BirthState) ? Player.BirthCountry : Player.BirthState);
                }
                return "N/A";
            }
        }

        public string Height
        {
            get { return string.Format("{0}' {1}''", Player.Height/12, Player.Height%12); }
        }

        public string Weight
        {
            get { return string.Format("{0}lbs", Player.Weight); }
        }

        public string Bats
        {
            get { return Enum.GetName(typeof (Constants.Bats), Player.Bats).Substring(0, 1); }
        }

        public string Throws
        {
            get { return Enum.GetName(typeof (Constants.Throws), Player.Throws).Substring(0, 1); }
        }

        public string HeadshotImageTag
        {
            get { return string.Format("<img src=\"{0}\" class=\"player-headshot\" data-playerId=\"{1}\"/>", Player.HeadShotUrl, Player.PlayerId); }
        }

        public string HeadshotUrl
        {
            get { return Player.HeadShotUrl; }
        }
    }
}