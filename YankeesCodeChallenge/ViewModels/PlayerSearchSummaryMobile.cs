using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
     public class PlayerSearchSummaryMobile : BasicPlayerModel
    {
        public PlayerSearchSummaryMobile(Player player)
        {
            InitializeBasicModel(player);
            base.HeadshotImage = string.Format("<img src=\"{0}\" class=\"player-headshot\" data-playerId=\"{1}\"/>", HeadshotImage, player.PlayerId);
            base.Team = player.Team.Abbreviation;
            base.League = base.League.Length > 3 ? base.League.Substring(0, 3) : base.League;
        }
    }
}