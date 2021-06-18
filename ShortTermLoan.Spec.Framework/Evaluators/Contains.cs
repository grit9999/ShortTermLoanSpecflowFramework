using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShortTermLoan.Specs.Framework.Evaluators
{
    public static class Contains
    {
        public static Func<ReadOnlyCollection<IWebElement>, bool> Text(string expectedText)
        {
            return (webElements) =>
            {
                return webElements.Any(x => x.Text.Trim().IndexOf(expectedText, StringComparison.OrdinalIgnoreCase) != -1);
            };
        }

        public static Func<ReadOnlyCollection<IWebElement>, bool> Item(string expectedText)
        {
            return (webElements) =>
            {
                return webElements.Any(x => string.Equals(x.Text.Trim(), expectedText, StringComparison.OrdinalIgnoreCase));
            };
        }

        public static Func<ReadOnlyCollection<IWebElement>, bool> Any()
        {
            return (webElements) =>
            {
                return webElements.Any();
            };
        }
    }
}
