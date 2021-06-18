using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ShortTermLoan.Spec.Framework.Extensions
{
    public static class PageExtensions
    {
        private static TimeSpan DefaultWait = TimeSpan.FromSeconds(5);

        public static T Navigate<T>(this T page, Func<T, Uri> selector)
            where T : PageComponent
        {
            page.Driver.Navigate().GoToUrl(selector(page));
            return page;
        }

        public static T Set<T>(this T page, Func<T, By> selector, string value)
            where T : PageComponent
        {
            page.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WaitTillVisible(page, selector);
            selector(page).FindElement(page.Driver).SendKeys(value);

            return page;
        }

        public static T PressKeys<T>(this T page, Func<T, By> selector, params string[] keys)
            where T : PageComponent
        {
            page.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            foreach (var key in keys)
            {
                selector(page).FindElement(page.Driver).SendKeys(key);
            }

            return page;
        }

        public static T Clear<T>(this T page, Func<T, By> selector)
            where T : PageComponent
        {
            page.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WaitTillVisible(page, selector);
            selector(page).FindElement(page.Driver).Clear();

            return page;
        }

        public static T SelectValue<T>(this T page, Func<T, By> selector, string value, bool deselect = false)
            where T : PageComponent
        {
            page.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WaitTillVisible(page, selector);
            var selectElement = new SelectElement(selector(page).FindElement(page.Driver));

            if (deselect && selectElement.IsMultiple)
            {
                selectElement.DeselectAll();
            }

            selectElement.SelectByText(value);

            return page;
        }

        public static T WaitTillExists<T>(this T page, Func<T, By> selector)
            where T : PageComponent => WaitTillExists(page, selector, DefaultWait);

        public static T WaitTillExists<T>(this T page, Func<T, By> selector, TimeSpan waitTime)
            where T : PageComponent
        {
            var wait = new WebDriverWait(page.Driver, waitTime);
            wait.Until(ExpectedConditions.ElementExists(selector(page)));

            return page;
        }

        public static T WaitTillVisible<T>(this T page, Func<T, By> selector)
            where T : PageComponent => WaitTillVisible(page, selector, DefaultWait);

        public static T WaitTillVisible<T>(this T page, Func<T, By> selector, TimeSpan waitTime)
            where T : PageComponent
        {
            var wait = new WebDriverWait(page.Driver, waitTime);
            wait.Until(ExpectedConditions.ElementIsVisible(selector(page)));

            return page;
        }

        public static T WaitTillNotVisible<T>(this T page, Func<T, By> selector)
            where T : PageComponent => WaitTillNotVisible(page, selector, DefaultWait);

        public static T WaitTillNotVisible<T>(this T page, Func<T, By> selector, TimeSpan waitTime)
            where T : PageComponent
        {
            var wait = new WebDriverWait(page.Driver, waitTime);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(selector(page)));

            return page;
        }

        public static T WaitTillClickable<T>(this T page, Func<T, By> selector)
            where T : PageComponent => WaitTillClickable(page, selector, DefaultWait);

        public static T WaitTillClickable<T>(this T page, Func<T, By> selector, TimeSpan waitTime)
            where T : PageComponent => WaitTillClickable(page, x => selector(page).FindElement(x.Driver), waitTime);

        public static T WaitTillClickable<T>(this T page, Func<T, IWebElement> selector)
            where T : PageComponent => WaitTillClickable(page, selector, DefaultWait);

        public static T WaitTillClickable<T>(this T page, Func<T, IWebElement> selector, TimeSpan waitTime)
            where T : PageComponent => WaitTillClickable(page, selector(page), waitTime);

        public static T WaitTillClickable<T>(this T page, IWebElement element)
            where T : PageComponent => WaitTillClickable(page, element, DefaultWait);

        public static T WaitTillClickable<T>(this T page, IWebElement element, TimeSpan waitTime)
            where T : PageComponent
        {
            var wait = new WebDriverWait(page.Driver, waitTime);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

            return page;
        }

        public static T Click<T>(this T page, Func<T, By> selector)
            where T : PageComponent => Click(page, selector, DefaultWait);

        public static T Click<T>(this T page, Func<T, By> selector, TimeSpan waitTime)
            where T : PageComponent => Click(page, selector(page).FindElement(page.Driver), waitTime);

        public static T Click<T>(this T page, Func<T, IWebElement> selector)
            where T : PageComponent => Click(page, selector, DefaultWait);

        public static T Click<T>(this T page, Func<T, IWebElement> selector, TimeSpan waitTime)
            where T : PageComponent => Click(page, selector(page), waitTime);

        public static T Click<T>(this T page, IWebElement element)
            where T : PageComponent => Click(page, element, DefaultWait);

        public static T Click<T>(this T page, IWebElement element, TimeSpan waitTime)
            where T : PageComponent
        {
            page.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WaitTillClickable(page, element, waitTime);
            element.Click();

            return page;
        }

        public static T Refresh<T>(this T page)
            where T : PageComponent
        {
            page.Driver.Navigate().Refresh();

            return page;
        }
    }
}
