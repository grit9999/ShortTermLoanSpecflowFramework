using System;
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
    public class VerifyMinimumLoanAmountDisplayedSteps
    {
        private readonly ShortTermLoanPage shortTermLoanPage = BrowserContext.CurrentPage<ShortTermLoanPage>();        
        private readonly string webPageUrl = ScenarioContext.Current.Get<string>("webPageUrl");
        
        [Given(@"I am on the Auden Short Term loan page")]
        public void GivenIAmOnTheAudenShortTermLoanPage()
        {           
           shortTermLoanPage.Driver.Navigate().GoToUrl(webPageUrl);
           shortTermLoanPage.WaitTillVisible(x => x.PageIdentifier);
        
           if(Is.Visible(shortTermLoanPage, shortTermLoanPage.AcceptCookiesButton))
            {
                shortTermLoanPage.Click(x => shortTermLoanPage.AcceptCookiesButton, TimeSpan.FromSeconds(5));
                shortTermLoanPage.WaitTillNotVisible(x => x.AcceptCookiesButton);
            }            
        }

        [When(@"move the slider to the minimum value of (.*)")]
        public void WhenMoveTheSliderToTheMinimumValueOf(int p0)
        {
            Actions actions = new Actions(shortTermLoanPage.Driver);
            var slider = shortTermLoanPage.Slider.FindElement(shortTermLoanPage.Driver);
            actions.MoveToElement(slider).Perform();
            int loanAmount = int.Parse(shortTermLoanPage.LoanAmountDisplayed.FindElement(shortTermLoanPage.Driver).Text.Replace("£", ""));
            int numberOfRetrys = 0;
            if (loanAmount != p0)
            {
                while(loanAmount != p0 && numberOfRetrys < 11)
                {
                    actions.DragAndDropToOffset(slider, -300, 0);
                    actions.Release();
                    actions.Build();
                    actions.Perform();
                    slider = shortTermLoanPage.Slider.FindElement(shortTermLoanPage.Driver);                    
                    loanAmount = int.Parse(shortTermLoanPage.LoanAmountDisplayed.FindElement(shortTermLoanPage.Driver).Text.Replace("£", ""));
                    numberOfRetrys++;
                }
            }
        }

        [Then(@"the loan amount also displays (.*)")]
        public void ThenTheLoanAmountAlsoDisplays(int p0)
        {
            int loanAmount = int.Parse(shortTermLoanPage.LoanAmountDisplayed.FindElement(shortTermLoanPage.Driver).Text.Replace("£", ""));
            NUnitAssert.IsTrue(loanAmount == p0,"Error: Loan Amount displayed does not match minimum value for slider");
        }
    }
}
