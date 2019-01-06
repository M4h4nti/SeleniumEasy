using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DatePicker
{
    [TestClass]
    [TestCategory("Date Pickers")]
    public class Bootstrap
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/");
        }

        [TestMethod]
        [Description("Date Example")]
        [TestProperty("Author", "VJKumar")]
        public void TCID1()
        {            
            driver.FindElement(By.XPath("//*[@id='navbar-brand-centered']//li/a[contains(.,'Date pickers')]")).Click();
            driver.FindElement(By.XPath("//*[@id='navbar-brand-centered']/ul[1]/li[2]/ul/li[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@class='input-group date']/span")).Click();
            driver.FindElement(By.XPath("//*[@class='datepicker-days']/table//tfoot/tr/th[contains(text(),'Today')]")).Click();
            string date = driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class='table-condensed']")).Text;
            Console.WriteLine(date);
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Assert.IsTrue(date.Equals(DateTime.Now.ToShortDateString()));

        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
