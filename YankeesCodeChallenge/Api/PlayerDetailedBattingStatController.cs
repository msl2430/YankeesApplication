using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YankeesCodeChallenge.Services;

namespace YankeesCodeChallenge.Api
{
    public class PlayerDetailedBattingStatController : ApiController
    {
        public HttpResponseMessage Get(int playerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, PlayerService.Current.FindDetailedBattingStatistics(playerId, DateTime.Now.AddYears(-2).Year, DateTime.Now.Year).OrderByDescending(bs => bs.Year));
        }
    }
}
