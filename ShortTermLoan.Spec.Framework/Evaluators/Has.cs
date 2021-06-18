using OpenQA.Selenium;
using System;

namespace PPX.Specs.Framework.Evaluators
{
    public static class Has
    {
        public static Func<IWebElement, bool> Text(string expectedText)
        {
            return (webElement) =>
            {
                return webElement.Text == expectedText;
            };
        }
    }
}
