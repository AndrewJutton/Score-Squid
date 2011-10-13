using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace ScoreSquid.Web.Functional.Tests.Steps
{
    public class LoginSteps
    {
        private IE ie;

        [Given(@"that I have an existing account")]
        public void GivenThatIHaveAnExistingAccount()
        {
            ie = new IE("http://localhost:51341");
        }

        [When(@"I enter valid login details")]
        public void WhenIEnterValidLoginDetails()
        {
            ie.TextField(Find.ById("Username")).TypeText("valid@gmail.com");
            ie.TextField(Find.ById("Password")).TypeText("valid");
        }

        [When(@"I submit my login request")]
        public void WhenISubmitMyLoginRequest()
        {
            ie.Button(Find.ByValue("Submit")).Click();
        }

        [Then(@"I should gain access to my account")]
        public void ThenIShouldGainAccessToMyAccount()
        {
            ie.Close();
        }
    }
}
