using OpenQA.Selenium;

namespace common
{
    public static class ElementExtensions
    {
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
