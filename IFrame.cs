using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class IFrame
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

        }

        [Test]
        public void ScrollDown()
        {
            //JavaScript interace for scroll down
            IWebElement sc = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", sc);

            // id, name, or index of frame
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            string text = driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine(text);

            driver.SwitchTo().DefaultContent();

            string text2 = driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine(text2);



        }

        [TearDown]
        public void CloseBrowser()
        {

        }

    }
}
