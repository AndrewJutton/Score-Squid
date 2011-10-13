using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;
using ScoreSquid.Web.Repositories.Commands;

namespace ScoreSquid.Web.Tests.Seed
{
    [TestClass]
    public class SeedFixtures
    {
        [TestMethod]
        public void SeedACoupleOfFixtures()
        {
            var teamRepository = new TeamRepository(new Commands());
            var divisionRepository = new DivisionRepository(new Commands());
            var fixtureRepository = new FixtureRepository(new Commands());

            var championship = divisionRepository.GetByIdentifier("E2");
            if (championship == null)
            {
                championship = new Division
                                   {
                                       DivisionIdentifier = "E2",
                                       Name = "Championship"
                                   };
                divisionRepository.Save(championship);
            }

            teamRepository.SaveNewTeam("Brighton", championship);
            var brighton = teamRepository.LoadTeamByName("Brighton");
            teamRepository.SaveNewTeam("West Ham", championship);
            var westHam = teamRepository.LoadTeamByName("West Ham");

            var fixture = new Fixture { HomeTeam = brighton, AwayTeam = westHam, Date = DateTime.Parse("23/10/2011") };
            fixtureRepository.Save(fixture);
        }
    }
}
