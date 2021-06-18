using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShortTermLoan.Spec.Framework.Extensions;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace ShortTermLoan.Spec.Framework
{
    [Binding]
    public class BrowserContext
    {
        private static IWebDriver Driver;

        [BeforeTestRun]
        public static void Initialize()
        {
            KillDriverProcesses("chrome");
            KillDriverProcesses("chromedriver");
            var options = new ChromeOptions();            
            //options.AddArgument("--window-size=1920,1200");
            options.AcceptInsecureCertificates = true;
            string dir = Directory.GetCurrentDirectory();            
            Driver = new ChromeDriver(options);
            
            //var size = Driver.Manage().Window.Size;
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public static PageComponent Page { get; private set; }

        public static T CurrentPage<T>() where T : PageComponent
        {
            if (Page == null || Page.GetType() != typeof(T))
                Page = (T)Activator.CreateInstance(typeof(T), Driver);
            return (T)Page;
        }
       
        public static void ClearBrowserCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public static void RefreshPage()
        {
            CurrentPage<PageComponent>().Refresh();
        }

        private static void KillDriverProcesses(string processName)
        {
            System.Diagnostics.Process[] chromeDriverProcessList = System.Diagnostics.Process.GetProcessesByName(processName);
            foreach (var process in chromeDriverProcessList)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        [AfterTestRun]
        public static void Dispose()
        {
            Driver.Quit();
            KillDriverProcesses("chrome");
            KillDriverProcesses("chromedriver");
        }

        [AfterScenario(Order = 0)]
        public static void CheckForFailure()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                try
                {
                    string fileNameBase = string.Format("error_{0}_{1}_{2}",
                                                        FeatureContext.Current.FeatureInfo.Title,
                                                        ScenarioContext.Current.ScenarioInfo.Title,
                                                        DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                    var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");

                    var screenshotDirectory = Path.Combine(artifactDirectory, "Screenshots");
                    if (!Directory.Exists(screenshotDirectory))
                        Directory.CreateDirectory(screenshotDirectory);

                    if (Driver is ITakesScreenshot takesScreenshot)
                    {
                        var screenshot = takesScreenshot.GetScreenshot();

                        var screenshotFilePath = Path.Combine(screenshotDirectory, fileNameBase + "_screenshot.png");
                        screenshot.SaveAsFile(screenshotFilePath);
                        TestContext.AddTestAttachment(screenshotFilePath);
                        Console.WriteLine("SCREENSHOT:{0}", screenshotFilePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while taking screenshot: {0}", ex);
                }
            }
        }
    }
}

