using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class CheckBoxDemo
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/basic-checkbox-demo.html");
        }

        [TestMethod]
        [Description("Clicking on the checkbox will display a success message")]
        [TestProperty("Author", "VJKumar")]
        public void SingleCheckBox()
        {
            var element = driver.FindElement(By.Id("isAgeSelected"));
            if (!element.Selected)
                element.Click();

            Assert.IsTrue(driver.FindElement(By.Id("txtAge")).Displayed);

            Console.WriteLine(driver.FindElement(By.Id("txtAge")).Text);
        }

        [TestMethod]
        [Description("Click on 'Check All' to check all checkboxes at once." +
            "When you check all the checkboxes, button will change to 'Uncheck All' " +
            "When you uncheck at least one checkbox, button will change to 'Check All'")]
        [TestProperty("Author", "VJKumar")]
        public void MultipleCheckBox()
        {
            var element = driver.FindElement(By.Id("check1"));
            Assert.AreEqual("Check All", element.GetAttribute("value"));
            element.Click();

            Assert.AreEqual("Uncheck All", element.GetAttribute("value"));

            ReadOnlyCollection<IWebElement> checkboxes = driver.FindElements(By.ClassName("cb1-element"));

            Console.WriteLine($"{checkboxes.Count}");
            SelectRandomCheckbox(checkboxes).Click();
            Assert.AreEqual("Check All", element.GetAttribute("value"));

            //Console.WriteLine(driver.FindElement(By.Id("txtAge")).Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        public IWebElement SelectRandomCheckbox(ReadOnlyCollection<IWebElement> Elements)
        {
            Random rand = new Random();
            int value = rand.Next(Elements.Count);
            return Elements[value];
        }
    }
}
