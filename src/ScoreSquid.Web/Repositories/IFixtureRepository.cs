using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Repositories
{
    public interface IFixtureRepository
    {
        List<Fixture> LoadAllFixtures();

        Fixture LoadFixtureBy(string homeTeamName, string awayTeamName);

        void SaveFixtureWithResult(Fixture fixture);
    }
}