using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Configuration;
using TechTalk.SpecFlow;

namespace ShortTermLoan.Spec.Framework
{
    public abstract class PageComponent
    {
        public readonly IWebDriver Driver;

        public PageComponent(IWebDriver driver)
        {
            Driver = driver;
        }

        public abstract string PageUri { get; }

        public abstract By PageIdentifier { get; }

        //public By ToastContainer => By.Id("toast-container");

        public bool OnPage()
        {
            try
            {
                Driver.FindElement(PageIdentifier);

                return true;
            }
            catch
            {
                // Ignore
            }

            return false;
        }
    }
}
