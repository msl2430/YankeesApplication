using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels;
using YankeesCodeChallenge.Configuration.Helpers;

namespace YankeesCodeChallenge.Services
{
    public class PlayerService : IPlayerService
    {
        private static PlayerService _service;

        private PlayerService() { }

        public static PlayerService Current
        {
            get { return _service ?? (_service = new PlayerService()); }
        }

        public ResultsWithCount<PlayerSummary> FindPlayerSummaryBySearchString(string search, int start, int max, int sortColIndex = -1, string sortDirection = "") 
        {
            var playerResult = PlayerBySearchString(search, start, max, sortColIndex, sortDirection);

            return playerResult;
        }

        #region Data Access
        protected ResultsWithCount<PlayerSummary> PlayerBySearchString(string search, int start, int max, int sortColIndex = -1, string sortDirection = "")
        {
            Team team = null;
            var query = NHibernateHelper.CurrentSession.QueryOver<Player>().JoinAlias(p => p.Team, () => team);
            var queryFiltered = NHibernateHelper.CurrentSession.QueryOver<Player>().ToRowCountQuery();
            var queryTotal = NHibernateHelper.CurrentSession.QueryOver<Player>().ToRowCountQuery();
            var queryResult = new ResultsWithCount<Player>();

            if (!string.IsNullOrEmpty(search))
            {
                var searchTerms = search.Split(' ').ToList();
                foreach (var st in searchTerms)
                {
                    query.Where(Restrictions.Disjunction()
                                            .Add(Restrictions.InsensitiveLike(Projections.Property<Player>(p => p.FirstName), st, MatchMode.Start))
                                            .Add(Restrictions.InsensitiveLike(Projections.Property<Player>(p => p.LastName), st, MatchMode.Start)));
                    queryFiltered.Where(Restrictions.Disjunction()
                                            .Add(Restrictions.InsensitiveLike(Projections.Property<Player>(p => p.FirstName), st, MatchMode.Start))
                                            .Add(Restrictions.InsensitiveLike(Projections.Property<Player>(p => p.LastName), st, MatchMode.Start)));
                }
            }

            if (sortDirection == "asc")
            {
                switch (sortColIndex)
                {
                    case 3:
                        query = query.OrderBy(p => p.Position).Asc.ThenBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                    case 4:
                        query = query.OrderBy(() => team.City).Asc.ThenBy(() => team.Name).Asc.ThenBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                    case 5:
                        query = query.OrderBy(() => team.LeagueId).Asc.ThenBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                    default:
                        query = query.OrderBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                }
            }
            else
            {
                switch (sortColIndex)
                {
                    case 3:
                        query = query.OrderBy(p => p.Position).Desc.ThenBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                    case 4:
                        query = query.OrderBy(() => team.City).Desc.ThenBy(() => team.Name).Asc.ThenBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                    case 5:
                        query = query.OrderBy(() => team.LeagueId).Desc.ThenBy(p => p.FirstName).Asc.ThenBy(p => p.LastName).Asc;
                        break;
                    default:
                        query = query.OrderBy(p => p.FirstName).Desc.ThenBy(p => p.LastName).Asc;
                        break;
                }
            }

            var multiQuery = NHibernateHelper.CurrentSession.CreateMultiCriteria();

            multiQuery.Add(query.Skip(start).Take(max))                      
                      .Add<int>(queryTotal)
                      .Add<int>(queryFiltered);

            var multiResult = multiQuery.List();
            queryResult.Results = ((IList) multiResult[0]).Cast<Player>().ToList();

            return new ResultsWithCount<PlayerSummary>()
                {
                    Results = ((IList) multiResult[0]).Cast<Player>().Select(p => new PlayerSummary(p)).ToList(),
                    ResultCount = ((IList) multiResult[1]).Cast<int>().ElementAt(0),
                    FilteredResultCount = ((IList) multiResult[2]).Cast<int>().ElementAt(0)
                };
        }
        #endregion
    }
}