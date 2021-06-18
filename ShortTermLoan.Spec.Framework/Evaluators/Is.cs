using OpenQA.Selenium;
using ShortTermLoan.Spec.Framework.Extensions;
using System;

namespace ShortTermLoan.Spec.Framework.Evaluators
{
    public static class Is
    {
        public static Func<PageComponent, bool> CurrentPage
        {
            get
            {
                return (page) =>
                {
                    try
                    {
                        page.WaitTillVisible(x => x.PageIdentifier);

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                };
            }
        }

        public static Func<PageComponent, By, bool> Visible
        {
            get
            {
                return (page, by) =>
                {
                    try
                    {
                        var element = by.FindElement(page.Driver);
                        return element.Displayed;
                    }
                    catch
                    {
                        return false;
                    }
                };
            }
        }

        public static Func<PageComponent, By, bool> Enabled
        {
            get
            {
                return (page, by) =>
                {
                    try
                    {
                        var element = by.FindElement(page.Driver);
                        return element.Enabled;
                    }
                    catch
                    {
                        return false;
                    }
                };
            }
        }
    }
}
