using System;
using System.IO;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.WebDriver.Extensions.JQuery;
using By = Selenium.WebDriver.Extensions.JQuery.By;

namespace SomeTests
{
    [TestFixture]
    public class WebpagesTests
    {
        [Test]
        public void ShouldFindFirstRecord()
        {
            using (IWebDriver webDriver = new ChromeDriver())
            {
                webDriver.Navigate().GoToUrl("http://jbzd.pl");
                var title = webDriver.FindElement(By.JQuerySelector(".title a:first"));

                Assert.That(title.Text.Length, Is.GreaterThan(0));

                webDriver.Close();
            }
        }

        [Test]
        public void ShouldPass()
        {
            Assert.Pass("Should pass everytime");
        }

        [Test]
        public void ShouldPass2()
        {
            Assert.Pass();
        }
    }
}
