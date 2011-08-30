using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Repositories
{
    public class FixtureRepository : IFixtureRepository
    {
        private IScoreSquidContext scoreSquidContext;

        public FixtureRepository(IScoreSquidContext scoreSquidContext)
        {
            this.scoreSquidContext = scoreSquidContext;
        }

        public List<Fixture> LoadAllFixtures()
        {
            return scoreSquidContext.Fixtures.ToList();
        }

        public Fixture LoadFixtureBy(string homeTeamName, string awayTeamName)
        {
            return scoreSquidContext.Fixtures.FirstOrDefault(x => x.HomeTeam.Name == homeTeamName && x.AwayTeam.Name == awayTeamName);
        }

        public void SaveFixtureWithResult(Fixture fixture)
        {
            scoreSquidContext.Fixtures.Add(fixture);
            scoreSquidContext.Save();
        }
    }
}