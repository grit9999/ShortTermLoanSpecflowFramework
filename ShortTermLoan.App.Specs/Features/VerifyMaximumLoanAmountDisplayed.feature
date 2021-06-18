Feature: VerifyMaximumLoanAmountDisplayed

Background: 
	Given I am using test data "VerifyMaximumLoanAmountTestData.json"

@specflow

Scenario: Verify Maximum Loan Amount Displayed
	Given I am on the Auden Short Term loan page	
	When move the slider to the maximum value of 500
	Then the loan amount also displays 500