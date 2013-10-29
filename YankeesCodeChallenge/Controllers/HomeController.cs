using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.Services;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var test = NHibernateHelper.CurrentSession.QueryOver<PitchingStat>().Take(1).SingleOrDefault<PitchingStat>();
            ViewBag.Name = "test";
            return View();
        }

        public ActionResult Test()
        {
            return View();
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
