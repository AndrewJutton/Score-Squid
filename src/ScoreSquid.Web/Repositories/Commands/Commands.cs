using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Player RegisterPlayer(ScoreSquidContext context, Player player)
        {
            context.Players.Add(player);
            context.Save();
            return player;
        }

        public bool TeamExists(ScoreSquidContext context, string teamName)
        {
            return context
                    .Teams
                    .Any(x => x.Name == teamName);
        }

        public void SaveNewTeam(ScoreSquidContext context, string teamName, Division division)
        {
            Team team = new Team { Name = teamName, Division = division };
            context.Teams.Add(team);
            context.Save();
        }

        public Team LoadTeamByName(ScoreSquidContext context, string teamName)
        {
            return context
                    .Teams
                    .Include(x => x.Division)
                    .FirstOrDefault(x => x.Name == teamName);
        }

        public Division LoadDivisionByIdentifier(ScoreSquidContext context, string divisionIdentifier)
        {
            return context
                    .Divisions
                    .FirstOrDefault(x => x.DivisionIdentifier.Equals(divisionIdentifier));
        }

        public Player LoginPlayer(ScoreSquidContext context, string username, string password)
        {
            return context
                .Players
                .FirstOrDefault(x => x.Username.Equals(username)
                    && x.Password.Equals(password));
        }

        public List<Team> GetAllTeams(ScoreSquidContext context)
        {
            return context
                    .Teams
                    .Include(x => x.Division)
                    .ToList();
        }

        public Team LoadTeamById(ScoreSquidContext context, int id)
        {
            return context
                    .Teams
                    .Include(x => x.Division)
                    .FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}