using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Context;

namespace ScoreSquid.Web.Repositories.Commands
{
    public class Commands : IFixtureCommands, IPlayerCommands, ITeamCommands
    {
        public List<Fixture> GetAllFixtures(ScoreSquidContext context)
        {
            return context.Fixtures.ToList();
        }

        public Fixture GetFixturesByHomeTeamNameAndAwayTeamName(ScoreSquidContext context, string homeTeamName, string awayTeamName)
        {
            return context.Fixtures.FirstOrDefault(x => x.HomeTeam.Name == homeTeamName && x.AwayTeam.Name == awayTeamName);
        }

        public void SaveFixture(ScoreSquidContext context, Fixture fixture)
        {
            context.Fixtures.Add(fixture);
            context.Save();
        }

        public bool RegisterPlayer(ScoreSquidContext context, Player player)
        {
            context.Players.Add(player);
            return context.Save();
        }

        public bool TeamExists(ScoreSquidContext context, string teamName)
        {
            return context.Teams.Any(x => x.Name == teamName);
        }

        public void SaveNewTeam(ScoreSquidContext context, string teamName, Division division)
        {
            Team team = new Team { Name = teamName, Division = division };
            context.Teams.Add(team);
            context.Save();
        }

        public Team LoadTeamByName(ScoreSquidContext context, string teamName)
        {
            return context.Teams.FirstOrDefault(x => x.Name == teamName);
        }

        public Division LoadDivisionByIdentifier(ScoreSquidContext context, string divisionIdentifier)
        {
            return context.Divisions.FirstOrDefault(x => x.DivisionIdentifier.Equals(divisionIdentifier));
        }
    }
}