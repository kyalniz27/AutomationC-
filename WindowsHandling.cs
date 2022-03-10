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
    internal class WindowsHandling
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.rahulshettyacademy.com/loginpagePractise";

        }

        [Test]
        public void WindowsHandle()
        {
            driver.FindElement(By.CssSelector(".blinkingText")).Click();

            //Switch driver to interact with second window
            Assert.AreEqual(2, driver.WindowHandles.Count); //2
            
            string child = driver.WindowHandles[1];

            driver.SwitchTo().Window(child);

            string text= driver.FindElement(By.CssSelector(".red")).Text;

            TestContext.Progress.WriteLine(text);

        }

        [Test]
        public void WindowsHandleGrabText()
        {
            string email = "mentor@rahulshettyacademy.com";

            driver.FindElement(By.CssSelector(".blinkingText")).Click();

            string parentWindow = driver.WindowHandles[0];
            string childWindow = driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindow);

            string text = driver.FindElement(By.CssSelector(".red")).Text;

            //Please email us at mentor@rahulshettyacademy.com with below template to receive response
           string[] splitText = text.Split("at");
           string[] trimText = splitText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimText[0]);

            TestContext.Progress.WriteLine("Trimmed email: "+trimText[0]);

            //Back to the parent window and past the email address you grabbed
            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.Id("username")).SendKeys(trimText[0]);

        }


        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
