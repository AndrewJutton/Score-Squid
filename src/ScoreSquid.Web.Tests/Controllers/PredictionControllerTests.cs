using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using MvcContrib.TestHelper;
using ScoreSquid.Web.Controllers;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Tasks;
using ScoreSquid.Web.Tests.Builders;

namespace ScoreSquid.Web.Tests.Controllers
{
    public class PredictionControllerTests
    {
        private static PredictionController controller;
        private static Mock<IPlayerTasks> mockPlayerTasks;

        Establish context = () =>
        {
            var controllerBuilder = new TestControllerBuilder();
            mockPlayerTasks = new Mock<IPlayerTasks>();

            controller = new PredictionController(mockPlayerTasks.Object);
            controllerBuilder.InitializeController(controller);
        };
    }

    [Subject(typeof(PredictionController), "LandingPageTests")]
    public class When_first_landing_on_the_predictions_page : PlayerControllerTests
    {
        private Machine.Specifications.It should_fetch_the_fixtures_for_the_logged_in_player = () =>
        {
            var miniLeague = new MiniLeague();
            var fixtures = miniLeague.MiniLeagueFixtures = new Collection<MiniLeagueFixture>();
            fixtures.Add(new MiniLeagueFixture { MiniLeague = miniLeague, Fixtures = new Collection<Fixture> { new Fixture { HomeTeam = new Team { Division = new Division().BuildDefault() } } }});
            var loggedInUser = new Player
            {
                MiniLeague = miniLeague
            };
                                                                                                   };
    }
}
