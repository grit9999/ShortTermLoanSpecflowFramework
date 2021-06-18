using ShortTermLoan.Spec.Framework;
using ShortTermLoan.App.Specs.Pages;
using OpenQA.Selenium.Interactions;
using NUnitAssert = NUnit.Framework.Assert;
using TechTalk.SpecFlow;

namespace ShortTermLoan.App.Specs.FeatureSteps
{
    [Binding]
    public class VerifyMaximumLoanAmountDisplayedSteps
    {
        private readonly ShortTermLoanPage shortTermLoanPage = BrowserContext.CurrentPage<ShortTermLoanPage>();
        private readonly string webPageUrl = ScenarioContext.Current.Get<string>("webPageUrl");

        [When(@"move the slider to the maximum value of (.*)")]
        public void WhenMoveTheSliderToTheMaximumValueOf(int p0)
        {
            Actions actions = new Actions(shortTermLoanPage.Driver);
            var slider = shortTermLoanPage.Slider.FindElement(shortTermLoanPage.Driver);
            actions.MoveToElement(slider).Perform();
            int loanAmount = int.Parse(shortTermLoanPage.LoanAmountDisplayed.FindElement(shortTermLoanPage.Driver).Text.Replace("£", ""));
            int numberOfRetrys = 0;
            if (loanAmount != p0)
            {
                while (loanAmount != p0 && numberOfRetrys < 11)
                {
                    actions.DragAndDropToOffset(slider, 300, 0);
                    actions.Release();
                    actions.Build();
                    actions.Perform();
                    slider = shortTermLoanPage.Slider.FindElement(shortTermLoanPage.Driver);
                    loanAmount = int.Parse(shortTermLoanPage.LoanAmountDisplayed.FindElement(shortTermLoanPage.Driver).Text.Replace("£", ""));
                    numberOfRetrys++;
                }
            }
        }
    }
}
