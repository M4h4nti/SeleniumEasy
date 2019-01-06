using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using common;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class InputFormValidation
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/input-form-demo.html");
        }

        [TestMethod]
        [Description("Input form with validations")]
        [TestProperty("Author", "VJKumar")]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FormValidation()
        {
            driver.FindElement(By.Name("first_name")).EnterText("Mahi");
            driver.FindElement(By.Name("last_name")).EnterText("kumar");
            driver.FindElement(By.Name("email")).EnterText("mahikumar1@live.");
            driver.FindElement(By.Name("phone")).EnterText("9998765432");
            driver.FindElement(By.Name("address")).EnterText("dtdghbjnk.,");
            driver.FindElement(By.Name("city")).EnterText("gfdrdhjhgy");
            new SelectElement(driver.FindElement(By.Name("state"))).SelectByText("Ohio");
            driver.FindElement(By.Name("zip")).EnterText("54328");
            driver.FindElement(By.Name("website")).EnterText("Csharp4selenium");
            driver.FindElement(By.Name("comment")).EnterText("Basic testing project");

            driver.FindElement(By.XPath("//*[@class='btn btn-default']")).Click();

            IReadOnlyList<IWebElement> errorElements = driver.FindElements(By.XPath("//*[@class='help-block' and @data-bv-result='INVALID']"));

            Console.WriteLine($"{errorElements.Count}");

            //Assert.IsTrue(errorElements.Count == 0, "Some thing went wrong");
            Assert.IsFalse(driver.FindElement(By.XPath("//*[@class='help-block' and @data-bv-result='INVALID']")).Displayed, "Some thing went wrong");

            //try
            //{

            //}
            //catch (NoSuchElementException)
            //{

            //    throw new NoSuchElementException("No Element");
            //}
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
