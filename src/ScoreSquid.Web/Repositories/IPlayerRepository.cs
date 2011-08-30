using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Repositories
{
    public interface IPlayerRepository
    {
        Player FindPlayer(string userId, string password);
        bool RegisterPlayer(Player player);
    }
}