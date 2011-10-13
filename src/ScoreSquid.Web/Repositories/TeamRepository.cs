using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories.Commands;

namespace ScoreSquid.Web.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private ITeamCommands commands;

        public TeamRepository(ITeamCommands commands)
        {
            this.commands = commands;
        }

        public bool TeamExists(string teamName)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.TeamExists(context, teamName);
            }
        }

        public void SaveNewTeam(string teamName, Division division)
        {
            using (var context = new ScoreSquidContext())
            {
                commands.SaveNewTeam(context, teamName, division);
            }
        }

        public Team LoadById(int id)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.LoadTeamById(context, id);
            }
        }

        public Team LoadTeamByName(string teamName)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.LoadTeamByName(context, teamName);
            }
        }

        public Division LoadDivisionByIdentifier(string divisionIdentifier)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.LoadDivisionByIdentifier(context, divisionIdentifier);
            }
        }

        public List<Team> GetAll()
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.GetAllTeams(context);
            }
        }
    }
}