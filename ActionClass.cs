using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class ActionClass
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/droppable";    

        }

        [Test]
        public void DragAndDrop()
        {
            Actions action = new Actions(driver);
            IWebElement source = driver.FindElement(By.Id("draggable"));
            IWebElement target = driver.FindElement(By.Id("droppable"));
            action.DragAndDrop(source, target).Perform();

        }

        [TearDown]
        public void CloseBrowser()
        {

        }
    }
}
