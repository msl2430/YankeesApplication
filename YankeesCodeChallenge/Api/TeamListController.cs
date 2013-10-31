using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YankeesCodeChallenge.Services;

namespace YankeesCodeChallenge.Api
{
    public class TeamListController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TeamService.Current.FindAllTeams().OrderBy(t => t.Name));
        }
    }
}
