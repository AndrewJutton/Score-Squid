using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScoreSquid.Web.Tasks;
using ScoreSquid.Web.Authentication;
using Machine.Specifications;
using Moq;
using ScoreSquid.Web.Controllers;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.ViewModels;
using MvcContrib.TestHelper;

namespace ScoreSquid.Web.Tests.Controllers
{
    public class PlayerControllerTests
    {
        protected static PlayerController controller;
        protected static Mock<IPlayerTasks> mockPlayerTasks;
        protected static Mock<ITeamTasks> mockTeamTasks;
        protected static Mock<IFormsAuthentication> mockFormsAuthentication;

        Establish context = () =>
        {
            var controllerBuilder = new TestControllerBuilder();

            mockPlayerTasks = new Mock<IPlayerTasks>();
            mockTeamTasks = new Mock<ITeamTasks>();
            mockFormsAuthentication = new Mock<IFormsAuthentication>();

            controller = new PlayerController(mockPlayerTasks.Object, mockTeamTasks.Object, mockFormsAuthentication.Object);
            controllerBuilder.InitializeController(controller);
        };

        Because user_logs_in = () =>
        {
            mockPlayerTasks.Setup(x => x.Login("valid@gmail.com", "valid")).Returns(new Player());
            mockFormsAuthentication.Setup(x => x.SignIn(Moq.It.IsAny<string>(), true));

            controller.ModelState.IsValid.ShouldBeTrue();
        };
    }

    [Subject(typeof(PlayerController), "LogInTests")]
    public class When_logging_into_application_with_good_username_and_password : PlayerControllerTests
    {
        Machine.Specifications.It user_should_navigate_to_the_mini_league_page = () =>
        {
            var model = new LoginViewModel
            {
                Username = "valid@gmail.com",
                Password = "valid",
                RememberMe = true
            };

            var result = controller.Login(model, string.Empty);

            result.AssertActionRedirect().ToAction<MiniLeagueController>(x => x.Index());
        };
    }

    [Subject(typeof(PlayerController), "LogInTests")]
    public class When_logging_into_application_with_bad_username_and_password : PlayerControllerTests
    {
        Machine.Specifications.It The_error_message_should_be_shown = () =>
        {
            var model = new LoginViewModel
            {
                Username = "bad@gmail.com",
                Password = "valid",
                RememberMe = true
            };

            var result = controller.Login(model, string.Empty);

            controller.ModelState[""].Errors[0].ErrorMessage.ShouldEqual(
                "The user name or password provided is incorrect.");

            result.AssertViewRendered();
        };
    }
}
