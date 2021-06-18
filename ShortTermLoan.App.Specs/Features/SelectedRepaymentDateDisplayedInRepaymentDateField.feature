Feature: SelectedRepaymentDateDisplayedInRepaymentDateField

Background: 
	Given I am using test data "SelectedRepaymentDateInRepaymentDateFieldTestData.json"

@specflow

Scenario: Selected Repayment Date Displayed In Repayment Date Field
	Given I am on the Auden Short Term loan page
	When select repayment date of 1 july 2021
	Then the first repayment date field matches 1 july 2021