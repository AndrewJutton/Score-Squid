using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IScoreSquidContext scoreSquidContext;

        public PlayerRepository(IScoreSquidContext scoreSquidContext)
        {
            this.scoreSquidContext = scoreSquidContext;
        }

        public Player FindPlayer(string userId, string password)
        {
            return new Player();
        }

        public bool RegisterPlayer(Player player)
        {
            scoreSquidContext.Players.Add(player);
            return scoreSquidContext.Save();
        }
    }
}