using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Tasks
{
    public interface IPlayerTasks
    {
        Player Login(string username, string password);

        Player Register(Player player);
    }
}
