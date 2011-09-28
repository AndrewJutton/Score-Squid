using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Context;

namespace ScoreSquid.Web.Repositories.Commands
{
    public interface IPlayerCommands
    {
        bool RegisterPlayer(ScoreSquidContext context, Player player);
    }
}