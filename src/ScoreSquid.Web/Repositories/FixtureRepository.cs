using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories.Commands;

namespace ScoreSquid.Web.Repositories
{
    public class FixtureRepository : IFixtureRepository
    {
        private IFixtureCommands commands;

        public FixtureRepository(IFixtureCommands commands)
        {
            this.commands = commands;
        }

        public List<Fixture> GetAll()
        {
            using(var context = new ScoreSquidContext())
            {
                return commands.GetAllFixtures(context);
            }
        }

        public Fixture GetByHomeTeamNameAndAwayTeamName(string homeTeamName, string awayTeamName)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.GetFixturesByHomeTeamNameAndAwayTeamName(context, homeTeamName, awayTeamName);
            }
        }

        public void Save(Fixture fixture)
        {
            using (var context = new ScoreSquidContext())
            {
                commands.SaveFixture(context, fixture);
            }
        }
    }
}