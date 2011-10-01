using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Tasks
{
    public interface ITeamTasks
    {
        List<Team> GetAll();

        Team LoadById(string id);
    }
}