using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Context;

namespace ScoreSquid.Web.Repositories.Commands
{
    public interface IFixtureCommands
    {
        List<Fixture> GetAllFixtures(ScoreSquidContext context);

        Fixture GetFixturesByHomeTeamNameAndAwayTeamName(ScoreSquidContext context, string homeTeamName, string awayTeamName);

        void SaveFixture(ScoreSquidContext context, Fixture fixture);
    }
}
