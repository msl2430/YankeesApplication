using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YankeesCodeChallenge.Models.DataObjects
{
    /// <summary>
    /// dbo.players
    /// </summary>
    public class Player
    {
        public virtual int PlayerId { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual int Bats { get; set; }

        public virtual int Throws { get; set; }

        public virtual Team Team { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual string BirthCity { get; set; }

        public virtual string BirthCountry { get; set; }

        public virtual string BirthState { get; set; }

        public virtual int? Height { get; set; }

        public virtual int? Weight { get; set; }

        public virtual int? Position { get; set; }

        public virtual int? Number { get; set; }

        public virtual string HeadShotUrl { get; set; }
    }
}