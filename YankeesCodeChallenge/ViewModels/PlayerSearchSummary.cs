﻿using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels.Helpers;

namespace YankeesCodeChallenge.ViewModels
{
    public class PlayerSearchSummary : PlayerSearchModel
    {
        public PlayerSearchSummary(Player player)
        {
            var playerHelper = new PlayerModelHelper(player);
            Initialize(playerHelper);          
        }
    }
}