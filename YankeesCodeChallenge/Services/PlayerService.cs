﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using YankeesCodeChallenge.Configuration.Helpers;
using YankeesCodeChallenge.Models.DataObjects;
using YankeesCodeChallenge.ViewModels;

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

        public IList<PlayerDetailedBattingStat> FindDetailedBattingStatistics(int playerId, int startYear, int endYear)
        {
            var battingStats = BattingStatsByPlayerId(playerId, startYear, endYear);

            return (battingStats != null && battingStats.Any()) ? battingStats.Select(bs => new PlayerDetailedBattingStat(bs)).ToList() : new List<PlayerDetailedBattingStat>();
        }

        public IList<PlayerDetailedPitchingStat> FindDetailedPitchingStatistics(int playerId, int startYear, int endYear)
        {
            var pitchintStats = PitchingStatsByPlayerId(playerId, startYear, endYear);

            return (pitchintStats != null && pitchintStats.Any()) ? pitchintStats.Select(ps => new PlayerDetailedPitchingStat(ps)).ToList() : new List<PlayerDetailedPitchingStat>();
        }

        public PlayerBio FindPlayerBioByPlayerId(int playerId)
        {
            var player = PlayerByPlayerId(playerId);

            return player != null ? new PlayerBio(player) : null;
        }

        public Player FindPlayerByPlayerId(int playerId)
        {
            var player = PlayerByPlayerId(playerId);

            return player;
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
                    Results = ((IList) multiResult[0]).Cast<Player>().Select(p => new PlayerSummary(p, p.PlayerId)).ToList(),
                    ResultCount = ((IList) multiResult[1]).Cast<int>().ElementAt(0),
                    FilteredResultCount = ((IList) multiResult[2]).Cast<int>().ElementAt(0)
                };
        }

        protected IList<BattingStat> BattingStatsByPlayerId(int playerId, int startYear, int endYear)
        {
            return NHibernateHelper.CurrentSession.QueryOver<BattingStat>()
                                         .Where(bs => bs.PlayerId == playerId && bs.YearId >= startYear && bs.YearId <= endYear)
                                         .List<BattingStat>();
        }

        protected IList<PitchingStat> PitchingStatsByPlayerId(int playerId, int startYear, int endYear)
        {
            return NHibernateHelper.CurrentSession.QueryOver<PitchingStat>()
                                         .Where(ps => ps.PlayerId == playerId && ps.YearId >= startYear && ps.YearId <= endYear)
                                         .List<PitchingStat>();
        } 

        protected Player PlayerByPlayerId(int playerId)
        {
            return NHibernateHelper.CurrentSession.QueryOver<Player>()
                                         .Where(p => p.PlayerId == playerId)
                                         .Take(1)
                                         .SingleOrDefault<Player>();
        }
        #endregion
    }
}