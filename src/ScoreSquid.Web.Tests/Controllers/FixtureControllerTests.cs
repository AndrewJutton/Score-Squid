using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreSquid.Web.Controllers;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;
using Moq;
using System.Web.Mvc;

namespace ScoreSquid.Web.Tests
{
    [TestClass]
    public class FixtureControllerTests
    {
        private Mock<IFixtureRepository> mockFixtureRepository;

        [TestInitialize]
        public void Setup()
        {
            Fixture fixture = new Fixture
                {
                    Date = DateTime.Today,
                    HomeTeam = new Team { Name = "Brighton" },
                    AwayTeam = new Team { Name = "Watford" }
                };

            List<Fixture> fixtures = new List<Fixture> { fixture };

            mockFixtureRepository = new Mock<IFixtureRepository>();
            mockFixtureRepository.Setup(x => x.GetAll()).Returns(fixtures);
        }

        [TestMethod]
        public void TestIndex_ShouldLoadAllFixtures()
        {
            var fixtureController = new FixtureController(mockFixtureRepository.Object);
            var result = fixtureController.Index() as ViewResult;
            List<Fixture> fixtures = result.Model as List<Fixture>;
            Assert.AreEqual(DateTime.Today, fixtures[0].Date);
            Assert.AreEqual("Brighton", fixtures[0].HomeTeam.Name);
            Assert.AreEqual("Watford", fixtures[0].AwayTeam.Name); 
        }
    }
}
