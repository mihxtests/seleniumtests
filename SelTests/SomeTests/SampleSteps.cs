using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.Extensions.JQuery;
using TechTalk.SpecFlow;
using By = Selenium.WebDriver.Extensions.JQuery.By;

namespace SomeTests
{
    [Binding]
    public class SomeSteps
    {
        public IWebDriver WebDriver
        {
            get { return (IWebDriver)ScenarioContext.Current["driver"]; }
            set { ScenarioContext.Current.Add("driver", value); }
        }

        [Given(@"I have open ""(.*)""")]
        public void GivenIHaveOpen(string webpage)
        {
            var webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(webpage);

            this.WebDriver = webDriver;
        }

        [Given(@"I have entered ""(.*)"" into search")]
        public void GivenIHaveEnteredIntoSearch(string searchValue)
        {
            var webDriver = this.WebDriver;

            var searchInput = webDriver.FindElement(By.JQuerySelector("#lst-ib"));
            searchInput.SendKeys(searchValue);
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            var webDriver = this.WebDriver;

            var button = webDriver.FindElement(By.JQuerySelector("button.lsb"));

            button.Submit();
        }

        [Then(@"The first result should start with ""(.*)""")]
        public void ThenTheFirstResultShouldStartWith(string result)
        {
            var webDriver = this.WebDriver;

            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var searchResult = wait.Until<IWebElement>(d => d.FindElements(By.JQuerySelector(".r a")).FirstOrDefault());
            var foundResult = searchResult.Text;
            webDriver.Close();

            Assert.That(foundResult, Does.StartWith(result));
        }
    }

}