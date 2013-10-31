using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Services
{
    public class TeamService : ITeamService
    {
        private static TeamService _service;

        private TeamService() { }

        public static TeamService Current
        {
            get { return _service ?? (_service = new TeamService()); }
        }

        public IList<TeamDetail> FindAllTeams()
        {
            var teamList = FulLTeamList();

            return (teamList != null && teamList.Any()) ? teamList.Select(tl => new TeamDetail(tl)).ToList() : new List<TeamDetail>();
        }

        #region Data Access
        protected IList<Team> FulLTeamList()
        {
            return NHibernateHelper.CurrentSession.QueryOver<Team>().List<Team>();
        } 
        #endregion
    }
}