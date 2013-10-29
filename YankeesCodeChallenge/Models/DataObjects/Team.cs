using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YankeesCodeChallenge.Models.DataObjects
{
    /// <summary>
    /// dbo.teams
    /// </summary>
    public class Team
    {
        public virtual int TeamId { get; set; }

        public virtual string City { get; set; }

        public virtual string Name { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual int? LeagueId { get; set; }
    }
}