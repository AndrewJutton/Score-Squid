using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories.Commands;

namespace ScoreSquid.Web.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IPlayerCommands commands;

        public PlayerRepository(IPlayerCommands commands)
        {
            this.commands = commands;
        }

        public Player FindPlayer(string userId, string password)
        {
            return new Player();
        }

        public bool RegisterPlayer(Player player)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.RegisterPlayer(context, player);
            }
        }
    }
}