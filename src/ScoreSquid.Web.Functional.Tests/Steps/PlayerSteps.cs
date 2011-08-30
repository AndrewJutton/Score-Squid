using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coypu;
using Coypu.Drivers.Selenium;
using TechTalk.SpecFlow;

namespace ScoreSquid.Web.Functional.Tests.Steps
{
    public class PlayerSteps
    {
        [Given(@"that I do not have an existing account")]
        public void GivenThatIDoNotHaveAnExistingAccount()
        {
            
        }

        [When(@"I navigate to the registration screen")]
        public void WhenINavigateToTheRegistrationScreen()
        {
            Configuration.AppHost = "localhost";
            Configuration.Port = 51341;
            Configuration.SSL = false;
            Configuration.Driver = typeof(SeleniumWebDriver);
            Configuration.Browser = Coypu.Drivers.Browser.Chrome;

            using (var browser = Browser.Session) 
            {
                browser.Visit("/Player/Register");
            }
        }

        [When(@"I enter my registration details")]
        public void WhenIEnterMyRegistrationDetails()
        {
        }

        [Then(@"I should successfully create an account")]
        public void ThenIShouldSuccessfullyCreateAnAccount()
        {
        }
    }
}
