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
            
            return View(new PlayerBioSummary(player));
        }

        /// <summary>
        /// Returns results for player table based on name filter, team filter, and sorting.
        /// </summary>
        /// <param name="tableOptions">jQuery Datatable parameters</param>
        /// <param name="optionalFilter">Optional list of filtering Ids to apply to the query</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetPlayerSummaryTable(List<aoData> tableOptions, string optionalFilter)
        {
            if (Request.Browser.IsMobileDevice)
            {
                var dataTableHelper = new DataTableHelper<PlayerSearchSummaryMobile>();
                dataTableHelper.Initialize(tableOptions);
                var results = PlayerService.Current.FindPlayerSummaryBySearchStringMobile(
                    dataTableHelper.SearchKey,
                    dataTableHelper.DisplayStart,
                    dataTableHelper.DisplayLength,
                    optionalFilter,
                    dataTableHelper.SortColumnIndex,
                    dataTableHelper.SortDirection);

                dataTableHelper.SetResults(results.Results.AsQueryable(), results.ResultCount, results.FilteredResultCount);
                return Json(new JavaScriptSerializer().Serialize(dataTableHelper.Parse()));
            }
            else
            {
                var dataTableHelper = new DataTableHelper<PlayerSearchSummary>();
                dataTableHelper.Initialize(tableOptions);
                var results = PlayerService.Current.FindPlayerSummaryBySearchString(
                    dataTableHelper.SearchKey,
                    dataTableHelper.DisplayStart,
                    dataTableHelper.DisplayLength,
                    optionalFilter,
                    dataTableHelper.SortColumnIndex,
                    dataTableHelper.SortDirection);

                dataTableHelper.SetResults(results.Results.AsQueryable(), results.ResultCount, results.FilteredResultCount);
                return Json(new JavaScriptSerializer().Serialize(dataTableHelper.Parse()));
            }
        }
    }
}
