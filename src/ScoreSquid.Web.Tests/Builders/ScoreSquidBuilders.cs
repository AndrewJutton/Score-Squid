using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Tests.Builders
{
    public static class ScoreSquidBuilders
    {
        public static Division BuildDefault(this Division division)
        {
            return new Division
                   {
                       DivisionIdentifier = "E2",
                       Id = 1,
                       Name = "Championship"
                   };
        }

        public static Team BuildDefault(this Team team, string name = "Brighton")
        {
            return new Team
                   {
                       Division = new Division().BuildDefault(),
                       DivisionId = 1,
                       Id = 1,
                       Name = name
                   };
        }

        public static MiniLeague BuildDefault(this MiniLeague miniLeague)
        {
            var miniLeagueFixture = new MiniLeagueFixture
                                    {
                                        MiniLeague = miniLeague,
                                        Fixtures = new Collection<Fixture>
                                                   {
                                                       new Fixture
                                                       {
                                                           HomeTeam = new Team().BuildDefault(),
                                                           AwayTeam = new Team().BuildDefault("West Ham")
                                                       }
                                                   }
                                    };

            return new MiniLeague
                   {
                       MiniLeagueFixtures = new Collection<MiniLeagueFixture> { miniLeagueFixture },
                       Name = "Insurecom Mini League"
                   
                   };
        }
    }
}
