using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;

namespace ScoreSquid.Web.Tasks
{
    public class TeamTasks : ITeamTasks
    {
        private ITeamRepository teamRepository;

        public TeamTasks(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public List<Team> GetAll()
        {
            return teamRepository.GetAll();
        }

        public Team LoadById(string id)
        {
            var teamId = 0;
            int.TryParse(id, out teamId);

            if (teamId != 0)
            {
                return teamRepository.LoadById(teamId);
            }

            return null;
        }
    }
}