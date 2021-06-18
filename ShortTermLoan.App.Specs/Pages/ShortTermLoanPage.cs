using OpenQA.Selenium;
using ShortTermLoan.Spec.Framework;
using System.Configuration;

namespace ShortTermLoan.App.Specs.Pages
{
    public class ShortTermLoanPage : PageComponent
    {
        public ShortTermLoanPage(IWebDriver driver) : base(driver)
        {
            _baseUrl = "https://www.auden.com/short-term-loan";
        }

        private readonly string _baseUrl;

        public override string PageUri => $@"{_baseUrl}";

        public override By PageIdentifier => AudenPageLogo;

        public By AudenPageLogo => By.CssSelector("body#auden div.cloudinary-svg");


        public By ConsentCookiesDialog => By.CssSelector("div.privacy_prompt explicit_consent");

        public By AcceptCookiesButton => By.Id("consent_prompt_submit");

        public By Slider => By.CssSelector("input[data-testid='loan-calculator-slider']");

        public By LoanAmountDisplayed => By.CssSelector("p[data-testid='loan-amount-value']");

        public By WantToBorrowAmount => By.CssSelector("strong[data-testid='loan-calculator-summary-amount']");

        public By RepaymentDateDisplayed => By.CssSelector("span[data-id='monthly'][class^='loan-schedule']");
        public By DateSelectorButtons => By.CssSelector("span.date-selector-date-1QvVP_ZsDC button#monthly");
    }
}
