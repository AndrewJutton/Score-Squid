using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Repositories
{
    public interface IPlayerRepository
    {
        Player Login(string username, string password);

        Player Register(Player player);
    }
}