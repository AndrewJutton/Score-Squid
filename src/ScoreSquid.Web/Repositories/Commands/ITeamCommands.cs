using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Repositories.Commands
{
    public interface ITeamCommands
    {
        bool TeamExists(ScoreSquidContext context, string teamName);

        void SaveNewTeam(ScoreSquidContext context, string teamName, Division division);

        Team LoadTeamByName(ScoreSquidContext context, string teamName);
    }
}