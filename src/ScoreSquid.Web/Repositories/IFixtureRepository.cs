using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Repositories
{
    public interface IFixtureRepository
    {
        List<Fixture> GetAll();

        Fixture GetByHomeTeamNameAndAwayTeamName(string homeTeamName, string awayTeamName);

        void Save(Fixture fixture);
    }
}