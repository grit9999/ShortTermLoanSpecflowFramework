using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace ShortTermLoan.Spec.Framework.Extensions
{
    public static class AssertExtensions
    {
        public static T Assert<T>(this T page, Func<PageComponent, bool> assertion, bool expected = true)
            where T : PageComponent
        {
            NUnit.Framework.Assert.AreEqual(expected, assertion(page));
            return page;
        }
        public static T Assert<T>(this T page, Func<T, By> selector, Func<PageComponent, By, bool> assertion, bool expected = true)
            where T : PageComponent
        {
            NUnit.Framework.Assert.AreEqual(expected, assertion(page, selector(page)));
            return page;
        }

        public static T Assert<T>(this T page, Func<T, By> selector, Func<IWebElement, bool> assertion, bool expected = true)
            where T : PageComponent
        {
            NUnit.Framework.Assert.AreEqual(expected, assertion(selector(page).FindElement(page.Driver)));
            return page;
        }

        public static T Assert<T>(this T page, Func<T, By> selector, Func<ReadOnlyCollection<IWebElement>, bool> assertion, bool expected = true)
            where T : PageComponent
        {
            NUnit.Framework.Assert.AreEqual(expected, assertion(selector(page).FindElements(page.Driver)));
            return page;
        }
    }
}
