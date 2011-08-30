using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Repositories
{
    public class TeamRepository : ScoreSquid.Web.Repositories.ITeamRepository
    {
        private IScoreSquidContext scoreSquidContext;

        public TeamRepository(IScoreSquidContext scoreSquidContext)
        {
            this.scoreSquidContext = scoreSquidContext;
        }

        public bool TeamExists(string teamName)
        {
            return scoreSquidContext.Teams.Any(x => x.Name == teamName);
        }

        public void SaveNewTeam(string teamName)
        {
            Team team = new Team { Name = teamName };
            scoreSquidContext.Teams.Add(team);
            scoreSquidContext.Save();
        }

        public Team LoadTeamByName(string teamName)
        {
            return scoreSquidContext.Teams.FirstOrDefault(x => x.Name == teamName);
        }
    }
}