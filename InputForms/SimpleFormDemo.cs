using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class SimpleFormDemo
    {
        private static readonly string message = "Hi Vijay";
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/basic-first-form-demo.html");
        }

        [TestMethod]
        [Description("Check message displayed in input field after clicking button")]
        [TestProperty("Author","VJKumar")]
        public void SingleInputField()
        {
            driver.FindElement(By.XPath("//input[@id='user-message']")).Clear();
            driver.FindElement(By.XPath("//input[@id='user-message']")).SendKeys(message);

            driver.FindElement(By.XPath("//*[@onclick='showInput();']")).Click();

            Assert.AreEqual(message,driver.FindElement(By.Id("display")).Text);
        }

        [TestMethod]
        [Description("Click on 'Get Total' button to display the sum of two numbers 'a and b'")]
        [TestProperty("Author","VJKumar")]
        public void MultipleInputField()
        {
            int a = 23;
            int b = 32;
            driver.FindElement(By.Id("sum1")).Clear();
            driver.FindElement(By.Id("sum1")).SendKeys(a.ToString());

            driver.FindElement(By.Id("sum2")).Clear();
            driver.FindElement(By.Id("sum2")).SendKeys(b.ToString());

            driver.FindElement(By.XPath("//*[@onclick='return total()']")).Click();

            Assert.AreEqual((a+b).ToString(), driver.FindElement(By.Id("displayvalue")).Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
