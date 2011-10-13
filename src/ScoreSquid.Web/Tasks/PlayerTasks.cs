using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;

namespace ScoreSquid.Web.Tasks
{
    public class PlayerTasks : IPlayerTasks
    {
        private IPlayerRepository playerRepository;

        public PlayerTasks(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public Player Login(string username, string password)
        {
            return playerRepository.Login(username, password);
        }

        public Player Register(Player player)
        {
            return playerRepository.Register(player);
        }
    }
}