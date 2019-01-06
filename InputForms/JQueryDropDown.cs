using System;
using System.Collections.Generic;
using common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class JQueryDropDown
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/jquery-dropdown-search-demo.html");
        }

        [TestMethod]
        [Description("Single Select - Search and Select country")]
        [TestProperty("Author", "VJKumar")]
        public void SingleSearchAndSelect()
        {
            driver.FindElement(By.XPath("//*[@id='select2-country-container']//parent::span")).Click();
            driver.FindElement(By.XPath("//*[@class='select2-search select2-search--dropdown']/input")).EnterText("ind");
            driver.FindElement(By.XPath("//ul[@id='select2-country-results']//li[text() = 'India']")).Click();
            string output = driver.FindElement(By.XPath("//*[@id='select2-country-container']//parent::span")).Text;
            Console.WriteLine(output);
            Assert.AreEqual("India", output);
        }

        [TestMethod]
        [Description("Multi Select - Search and Select country")]
        [TestProperty("Author", "VJKumar")]
        public void MultiSearchAndSelect()
        {
            driver.FindElement(By.XPath("//input[@placeholder='Select state(s)']")).Click();
            //driver.FindElement(By.XPath("//*[@class='select2-search select2-search--dropdown']/input")).EnterText("ind");
            driver.FindElement(By.XPath("//li[contains(@id,'AK')]")).Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//ul[@class='select2-selection__rendered']")).Click();
            driver.FindElement(By.XPath("//li[contains(@id,'OH')]")).Click();
            IList<IWebElement> outputCollection = driver.FindElements(By.XPath("//ul[@class='select2-selection__rendered']"));
            foreach(var output in outputCollection)
            {
                Console.WriteLine(output.Text);
            }
            
            //Assert.AreEqual("India", output);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
