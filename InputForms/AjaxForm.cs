using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using common;
using OpenQA.Selenium.Support.UI;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class AjaxForm
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/ajax-form-submit-demo.html");
        }

        [TestMethod]
        [Description("Ajax Form Submit with Loading icon")]
        [TestProperty("Author", "VJKumar")]
        public void AjaxFormCheck()
        {
            driver.FindElement(By.Id("title")).EnterText("Mahi");
            driver.FindElement(By.Id("description")).EnterText("hi");
            driver.FindElement(By.Id("btn-submit")).Click();
            string output = driver.FindElement(By.Id("submit-control")).Text;
            Console.WriteLine(output);
            Assert.AreEqual("Ajax Request is Processing!", output);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.Id("submit-control")), "Form submited Successfully!"));
            Assert.AreEqual("Form submited Successfully!", driver.FindElement(By.Id("submit-control")).Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
