using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DatePicker
{
    [TestClass]
    [TestCategory("")]
    public class Jquery
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("");
        }

        [TestMethod]
        [Description("")]
        [TestProperty("Author", "VJKumar")]
        public void TCID1()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
