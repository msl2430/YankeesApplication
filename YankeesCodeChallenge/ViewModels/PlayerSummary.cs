using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YankeesCodeChallenge.Configuration;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerSummary
    {
        public MvcHtmlString HeadshotImage { get; set; }

        public string FullName { get; internal set; }

        public string Number { get; internal set; }

        public string Position { get; internal set; }
        
        public string Team { get; internal set; }

        public string League { get; set; }

        public PlayerSummary(Player player)
        {
            FullName = string.Concat(player.FirstName, " ", player.LastName);
            Number = player.Number == null ? "N/A" : player.Number.ToString();
            Position = Constants.Position.Positions.Any(p => p.Id == player.Position) ? Constants.Position.Positions.FirstOrDefault(p => p.Id == player.Position).Name : "N/A";
            Team = string.Concat(player.Team.City, " ", player.Team.Name);
            League = player.Team.LeagueId != null ? Enum.GetName(typeof (Constants.League), (int) player.Team.LeagueId) : "N/A";
            HeadshotImage = new MvcHtmlString(string.Format("<img class=\"player-headshot\" src=\"{0}\" data-playerId=\"{1}\" />", player.HeadShotUrl, player.PlayerId.ToString()));
        }
    }
}