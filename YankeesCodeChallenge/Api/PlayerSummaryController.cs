using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Services;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Api
{
    public class PlayerSummaryController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(List<aoData> tableOptions, string optionalFilter)
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

            return Request.CreateResponse(HttpStatusCode.OK, dataTableHelper.Parse());
        }
    }
}
