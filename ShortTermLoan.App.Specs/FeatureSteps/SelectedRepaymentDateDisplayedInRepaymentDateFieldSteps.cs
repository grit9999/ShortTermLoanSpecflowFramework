using System;
using TechTalk.SpecFlow;

namespace ShortTermLoan.App.Specs.FeatureSteps
{
    [Binding]
    public class SelectedRepaymentDateDisplayedInRepaymentDateFieldSteps
    {
        [When(@"select repayment date of (.*) july (.*)")]
        public void WhenSelectRepaymentDateOfJuly(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"the first repayment date field matches (.*) july (.*)")]
        public void ThenTheFirstRepaymentDateFieldMatchesJuly(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
