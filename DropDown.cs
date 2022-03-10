using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SeleniumLearning
{
    public class DropDown
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void DropDownTest()
        {
            driver.FindElement(By.Id("username")).SendKeys("new_user");
            driver.FindElement(By.Id("password")).SendKeys("test1234");
            IList<IWebElement>  rdos = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach(IWebElement rd in rdos)
            {
                if (rdos[1].GetAttribute("value").Equals("user"))
                {
                    rd.Click();
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            
          //  bool result = driver.FindElement(By.Id("usertype")).Selected;
           // Assert.IsFalse(result);
            
            IWebElement drop = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement select = new SelectElement(drop);
            //select.SelectByText("Teacher");
            //select.SelectByValue("teach");
            select.SelectByIndex(2);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
