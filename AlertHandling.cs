using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class AlertHandling
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

        }

       [Test]
       public void AlertConcept()
        {
            driver.FindElement(By.Name("enter-name")).SendKeys("Hello World");
            driver.FindElement(By.Id("confirmbtn")).Click();

            String name = "Hello";
            string alert_text = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            
            TestContext.Progress.WriteLine(alert_text);

            //To verify if the name is present in alert text
            StringAssert.Contains(name, alert_text);

        }

        [Test]
        public void auto_suggestive()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("us");
            Thread.Sleep(2000);

            IList<IWebElement> countries = driver.FindElements(By.CssSelector(".ui-menu-item"));

            foreach (IWebElement country in countries)
            {
                if (country.Text.Equals("United States (USA)"))
                {
                    country.Click();
                }
            }

            string textbox = driver.FindElement(By.Id("autocomplete")).GetAttribute("value");
            TestContext.Progress.WriteLine(textbox);    

        }

        [Test]
        public void test_action()
        {
            driver.Url = "https://www.rahulshettyacademy.com/#/index";
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
        }


        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }



    }
}
