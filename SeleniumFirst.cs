using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();

            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new ChromeDriver();

            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //driver = new FirefoxDriver();

            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";
            string title = driver.Title;
            TestContext.Progress.WriteLine(title);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
