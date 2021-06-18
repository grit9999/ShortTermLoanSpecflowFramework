Feature: Minimum Loan Amount	

Background: 
	Given I am using test data "VerifyMinimumLoanAmountTestData.json"

@specflow

Scenario: Verify Minimum Loan Amount Displayed
	Given I am on the Auden Short Term loan page	
	When move the slider to the minimum value of 200
	Then the loan amount also displays 200