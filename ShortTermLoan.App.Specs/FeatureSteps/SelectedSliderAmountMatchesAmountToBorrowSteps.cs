using System;
using System.Collections.Generic;
using ShortTermLoan.Spec.Framework;
using ShortTermLoan.App.Specs.Pages;
using OpenQA.Selenium.Interactions;
using NUnitAssert = NUnit.Framework.Assert;
using TechTalk.SpecFlow;

namespace ShortTermLoan.App.Specs.FeatureSteps
{
    [Binding]
    public class SelectedSliderAmountMatchesAmountToBorrowSteps
    {
        private readonly ShortTermLoanPage shortTermLoanPage = BrowserContext.CurrentPage<ShortTermLoanPage>();
        private readonly string webPageUrl = ScenarioContext.Current.Get<string>("webPageUrl");

        [When(@"move the slider to the value of (.*)")]
        public void WhenMoveTheSliderToTheValueOf(int p0)
        {
            Actions actions = new Actions(shortTermLoanPage.Driver);
            var slider = shortTermLoanPage.Slider.FindElement(shortTermLoanPage.Driver);
            actions.MoveToElement(slider).Perform();
            int loanAmount = int.Parse(shortTermLoanPage.LoanAmountDisplayed.FindElement(shortTermLoanPage.Driver).Text.Replace("£", ""));            
            actions.DragAndDropToOffset(slider, -500, 0);
            actions.Release();
            actions.Build();
            actions.Perform();

            actions.DragAndDropToOffset(slider, 0, 0);
            actions.Release();
            actions.Build();
            actions.Perform();
        }
        
        [Then(@"the amount to borrow amount also displays (.*)")]
        public void ThenTheAmountToBorrowAmountAlsoDisplays(int p0)
        {
            string wantBorrowAmountWithoutPoundSymbol = shortTermLoanPage.WantToBorrowAmount
                                                        .FindElement(shortTermLoanPage.Driver).Text.Replace("£", "");
            int length = wantBorrowAmountWithoutPoundSymbol.Length;
            int wantToBorrowAmount = int.Parse(wantBorrowAmountWithoutPoundSymbol.Remove(length - 3));
            NUnitAssert.IsTrue(wantToBorrowAmount == p0, "Error: Want to borrow Amount displayed does not match " +p0 +" value for slider");
        }
    }
}