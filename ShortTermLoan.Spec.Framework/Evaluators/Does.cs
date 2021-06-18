using OpenQA.Selenium;
using ShortTermLoan.Spec.Framework.Extensions;
using System;

namespace ShortTermLoan.Spec.Framework.Evaluators
{
    public static class Does
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

        public static Func<PageComponent, By, bool> Exist
        {
            get
            {
                return (page, by) =>
                {
                    try
                    {
                        var element = by.FindElement(page.Driver);
                        return element != null;
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
