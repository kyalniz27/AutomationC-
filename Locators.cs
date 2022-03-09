using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LoginPage()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("test1234");
            //driver.FindElement(By.XPath("//*[@class='checkmark']/following::span[2]")).Click();
            driver.FindElement(By.XPath("//div[@class='form-group']/label/span/input")).Click();
            driver.FindElement(By.Name("signin")).Click();

            //WebDriverWait concept
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
            TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")),"Sign In"));

            string error_message = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(error_message);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            string attribueName = link.GetAttribute("href");
            string expected = "https://rahulshettyacademy.com/#/documents-request";

            //Validating of the url linktext
            Assert.AreEqual(expected, attribueName);

        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
    }
  
}
