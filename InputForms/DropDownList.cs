using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class DropDOwnList
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
        }

        [TestMethod]
        [Description("Selected value from the list will display below the dropdown")]
        [TestProperty("Author", "VJKumar")]
        public void SelectList()
        {
            IWebElement singleElement = driver.FindElement(By.Id("select-demo"));
            ReadOnlyCollection<IWebElement> dayList = driver.FindElements(By.XPath("//*[@id='select-demo']/option"));
            string day = SelectRandomValues(dayList).Text;
            new SelectElement(singleElement).SelectByText(day);

            Assert.IsTrue(driver.FindElement(By.ClassName("selected-value")).Text.Contains(day));
        }

        [TestMethod]
        [Description("By clicking on the buttons, you can get value from the list which will display just below the buttons")]
        [TestProperty("Author", "VJKumar")]
        public void MultiSelectList()
        {
            //driver.FindElement(By.Id("printMe")).Click();
            IWebElement output = driver.FindElement(By.ClassName("getall-selected"));
            //Console.WriteLine($"{output.Text}");
            //Assert.IsTrue(output.Text.Contains("undefined"));

            IWebElement singleElement = driver.FindElement(By.Id("multi-select"));
            ReadOnlyCollection<IWebElement> cityList = singleElement.FindElements(By.TagName("option"));
            //string city = SelectRandomValues(cityList).Text;
            SelectElement ddlMultiSelect = new SelectElement(singleElement);
            singleElement.SendKeys(Keys.Control);
            //cityList[4].Click();
            //cityList[1].Click();
            //cityList[7].Click();
            ddlMultiSelect.DeselectAll();
            singleElement.SendKeys(Keys.Control);
            ddlMultiSelect.SelectByText("Ohio");
            singleElement.SendKeys(Keys.Control);
            ddlMultiSelect.SelectByText("Florida");
            //ddlMultiSelect.SelectByIndex(7);

            IList<IWebElement> selectedOptions = ddlMultiSelect.AllSelectedOptions;
            Console.WriteLine($"{selectedOptions.Count}");
            //IWebElement output = driver.FindElement(By.ClassName("getall-selected"));           

            //printAll
            driver.FindElement(By.Id("printAll")).Click();
            Assert.IsTrue(output.Text.Contains("Florida"));

            //driver.FindElement(By.Id("printMe")).Click();
            Console.WriteLine($"{output.Text}");
            //Console.WriteLine($"{newElement.SelectedOption.Text}");
            //Assert.IsTrue(output.Text.Contains("Ohio"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        public IWebElement SelectRandomValues(ReadOnlyCollection<IWebElement> Elements)
        {
            Random random = new Random();
            return Elements[random.Next(1,Elements.Count)];
        }
    }
}
