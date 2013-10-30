using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.Core;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.Services;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlayerBio(int? playerId)
        {
            if (playerId == null)
                return RedirectToAction("Index", "Home");

            var player = PlayerService.Current.FindPlayerByPlayerId((int) playerId);
            if (player == null)
                return RedirectToAction("Index", "Home");
            
            return View(new PlayerSummary(player));
        }

        public JsonResult GetPlayerSummaryTable(List<aoData> tableOptions)
        {
            var dataTableHelper = new DataTableHelper<PlayerSummary>();
            dataTableHelper.Initialize(tableOptions);

            var results = PlayerService.Current.FindPlayerSummaryBySearchString(
                dataTableHelper.SearchKey,
                dataTableHelper.DisplayStart,
                dataTableHelper.DisplayLength,
                dataTableHelper.SortColumnIndex,
                dataTableHelper.SortDirection);

            dataTableHelper.SetResults(results.Results.AsQueryable(), results.ResultCount, results.FilteredResultCount);

            return Json(new JavaScriptSerializer().Serialize(dataTableHelper.Parse()));
        }
    }
}
