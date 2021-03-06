using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class FunctionalTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LoginPage()
        {
            string[] expectedProducts = {"iphone X","Blackberry"};
            string[] actualProducts = new string[2];

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group']/label/span/input")).Click();
            driver.FindElement(By.Name("signin")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
            ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products =  driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                string text =  product.FindElement(By.CssSelector(".card-title a")).Text;
                //TestContext.Progress.WriteLine(text);

                if (expectedProducts.Contains(text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                
             
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            
            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));
            for(int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;

            }

            Assert.AreEqual(expectedProducts, actualProducts);

            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Id("country")).SendKeys("bel");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Belarus")));

            driver.FindElement(By.PartialLinkText("Belarus")).Click();

            driver.FindElement(By.XPath("//*[@for='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confrimText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success!", confrimText);


        }

        [TearDown]
        public void TearDown()
        {
          driver.Quit();
        }

    }
}
