using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowNetCoreDemo.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowNetCoreDemo.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        //Anti-Context Injection code - 100% wrong??
        LoginPage loginPage = null;


        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");
            loginPage = new LoginPage(webDriver);
        }

        [Given(@"I click login link")]
        public void GivenIClickLoginLink()
        {
            loginPage.ClickLogin();
        }

        [When(@"I enter the following details")]
        public void WhenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((string) data.UserName, (string) data.Password);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see Employee details link")]
        public void ThenIShouldSeeEmployeeDetailsLink()
        {
            Assert.That(loginPage.IsEmployeeDetailsExist(), Is.True);
        }

    }
}
