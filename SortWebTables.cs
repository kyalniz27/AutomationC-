using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SortWebTables
    {
        IWebDriver driver;
        SelectElement dropdown;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

        }

        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();

            dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@id='page-menu']")));
            dropdown.SelectByText("20");

            // 1- Get all product names in an array list (A)
            IList<IWebElement> veggies  = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }

            // 2- Sort this array list
            a.Sort();
            foreach(string x in a)
            {
                TestContext.Progress.WriteLine(x);
            }

            // 3- Go and click the column
            driver.FindElement(By.XPath("//*[@scope='col' and @aria-sort='descending']")).Click();

            // 4- Again grab all the sorted products (B)
            ArrayList b = new ArrayList();
            IList<IWebElement> sorted_veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement sorted_veggie in sorted_veggies)
            {
                b.Add(sorted_veggie.Text);
            }

            // arraylist A and B should be the same
            Assert.AreEqual(a,b);

        }

        [TearDown]
        public void EndBrowser()
        {
            driver.Quit();
        }
    }
}
