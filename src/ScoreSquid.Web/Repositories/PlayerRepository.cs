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

        public Player Login(string username, string password)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.LoginPlayer(context, username, password);
            }
        }

        public Player Register(Player player)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.RegisterPlayer(context, player);
            }
        }
    }
}