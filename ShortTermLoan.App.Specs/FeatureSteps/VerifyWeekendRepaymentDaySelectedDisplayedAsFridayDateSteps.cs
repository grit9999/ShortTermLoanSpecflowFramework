using System;
using System.Collections.Generic;
using ShortTermLoan.Spec.Framework;
using ShortTermLoan.Spec.Framework.Evaluators;
using ShortTermLoan.Spec.Framework.Extensions;
using ShortTermLoan.App.Specs.Pages;
using OpenQA.Selenium.Interactions;
using NUnitAssert = NUnit.Framework.Assert;
using TechTalk.SpecFlow;

namespace ShortTermLoan.App.Specs.FeatureSteps
{
    [Binding]
    public class VerifyWeekendRepaymentDaySelectedDisplayedAsFridayDateSteps
    {
        private readonly ShortTermLoanPage shortTermLoanPage = BrowserContext.CurrentPage<ShortTermLoanPage>();
        private readonly string webPageUrl = ScenarioContext.Current.Get<string>("webPageUrl");
        private readonly string weekendRepaymentDate = ScenarioContext.Current.Get<string>("weekendRepaymentDate");

        [When(@"enter weekend repayment date of (.*) July (.*)")]
        public void WhenEnterWeekendRepaymentDateOfJuly(int p0, int p1)
        {            
            var driver = shortTermLoanPage.Driver;
            var listOfDateButtons = shortTermLoanPage.DateSelectorButtons.FindElements(driver);
            int indexToSelect = p0 - 1;
            var buttonToSelect = listOfDateButtons[indexToSelect];

            Actions actions = new Actions(shortTermLoanPage.Driver);
            actions.MoveToElement(buttonToSelect).Perform();

            shortTermLoanPage.Click(x => x.DateSelectorButtons.FindElements(driver)[2]);
            shortTermLoanPage.WaitTillVisible(x => x.RepaymentDateDisplayed);
            var repaymentDateField = shortTermLoanPage.RepaymentDateDisplayed.FindElement(shortTermLoanPage.Driver);
            actions.MoveToElement(repaymentDateField).Perform();
        }
        
        [Then(@"repayment date should be pushed back to a friday date")]
        public void ThenRepaymentDateShouldBePushedBackToAFridayDate()
        {
            var repaymentDateField = shortTermLoanPage.RepaymentDateDisplayed.FindElement(shortTermLoanPage.Driver);
            string dateExpected = "Friday 2 Jul 2021";
            NUnitAssert.IsTrue(repaymentDateField.Text.Contains("Friday"),"Error: day should been pushed back to friday for weekend date");
            NUnitAssert.IsTrue(repaymentDateField.Text == dateExpected, "Error: day should been pushed back to friday for weekend date");
        }
    }
}
