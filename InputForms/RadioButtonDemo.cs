using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InputForms
{
    [TestClass]
    [TestCategory("Input Form")]
    public class RadioButtonDemo
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.seleniumeasy.com/test/basic-radiobutton-demo.html");
        }

        [TestMethod]
        [Description("Click on button to get the selected value")]
        [TestProperty("Author", "VJKumar")]
        public void RadioButton()
        {
            driver.FindElement(By.Id("buttoncheck")).Click();

            Assert.AreEqual("Radio button is Not checked", driver.FindElement(By.XPath("//p[@class='radiobutton']")).Text);
            //Radio button is Not checked

            ReadOnlyCollection<IWebElement> radioButtons = driver.FindElements(By.Name("optradio"));
            IWebElement Element = GetRandomRadioButton(radioButtons);

            string value = Element.GetAttribute("value");
            Element.Click();

            driver.FindElement(By.Id("buttoncheck")).Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//p[@class='radiobutton']")).Text.Contains(value));

            Console.WriteLine($"{value}");
        }

        [TestMethod]
        [Description("Click on button to get the selected values from Group Sex and Age group")]
        [TestProperty("Author", "VJKumar")]
        public void GroupRadioButton()
        {
            ReadOnlyCollection<IWebElement> radioButtonsGender = driver.FindElements(By.Name("gender"));
            IWebElement GenderElement = GetRandomRadioButton(radioButtonsGender);

            string gendervalue = GenderElement.GetAttribute("value");
            GenderElement.Click();

            ReadOnlyCollection<IWebElement> radioButtonsAge = driver.FindElements(By.Name("ageGroup"));
            IWebElement AgeElement = GetRandomRadioButton(radioButtonsAge);

            string agevalue = AgeElement.GetAttribute("value");
            AgeElement.Click();

            driver.FindElement(By.XPath("//*[@onclick='getValues();']")).Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//p[@class='groupradiobutton']")).Text.Contains(gendervalue));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        private IWebElement GetRandomRadioButton(ReadOnlyCollection<IWebElement> Elements)
        {
            Random rand = new Random();
            return Elements[rand.Next(Elements.Count)];
        }
    }
}
