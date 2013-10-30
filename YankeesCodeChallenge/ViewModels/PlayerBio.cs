using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YankeesCodeChallenge.Configuration;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerBio : BasicPlayerModel
    {
        public string BirthDate { get; set; }

        public string BirthLocation { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string Bats { get; set; }

        public string Throws { get; set; }

        public PlayerBio(Player player)
        {
            InitializeBasicModel(player);
            BirthDate = player.BirthDate != null ? Convert.ToDateTime(player.BirthDate).ToShortDateString() : "N/A";
            BirthLocation = FormatBirthLocation(player);
            Height = string.Format("{0}' {1}''", player.Height/12, player.Height%12);
            Weight = string.Format("{0}lbs", player.Weight);
            Bats = Enum.GetName(typeof (Constants.Bats), player.Bats).Substring(0, 1);
            Throws = Enum.GetName(typeof(Constants.Throws), player.Throws).Substring(0, 1);
        }

        private string FormatBirthLocation(Player player)
        {
            if (!string.IsNullOrEmpty(string.Concat(player.BirthCity, player.BirthCountry, player.BirthState)))
            {
                return string.Format("{0}, {1}", player.BirthCity, string.IsNullOrEmpty(player.BirthState) ? player.BirthCountry : player.BirthState);
            }
            return "N/A";
        }
    }
}