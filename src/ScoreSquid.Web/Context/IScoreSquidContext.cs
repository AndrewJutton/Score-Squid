using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Context
{
    public interface IScoreSquidContext
    {
        IDbSet<Season> Seasons { get; set; }
        IDbSet<Team> Teams { get; set; }
        IDbSet<Fixture> Fixtures { get; set; }
        IDbSet<MiniLeague> MiniLeagues { get; set; }
        IDbSet<Player> Players { get; set; }

        bool Save();
    }
}