using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YankeesCodeChallenge.Services;

namespace YankeesCodeChallenge.Api
{
    public class PlayerBioController : ApiController
    {
        public HttpResponseMessage Get(int playerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, PlayerService.Current.FindPlayerBioByPlayerId(playerId));
        }
    }
}
