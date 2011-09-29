using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Context
{
    public class ScoreSquidContext : DbContext, IScoreSquidContext
    {
        public ScoreSquidContext() : base(@"name=ScoreSquidContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Season> Seasons { get; set; }
        public IDbSet<Division> Divisions { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Fixture> Fixtures { get; set; }
        public IDbSet<MiniLeague> MiniLeagues { get; set; }
        public IDbSet<Player> Players { get; set; }

        public bool Save()
        {
            return SaveChanges() > 0;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
