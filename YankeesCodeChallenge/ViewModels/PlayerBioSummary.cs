using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerBioSummary : BasicPlayerModel
    {
        public PlayerBioSummary(Player player)
        {
            InitializeBasicModel(player);
        }
    }
}