Feature: VerifyWeekendWeekendRepaymentDaySelectedDisplayedAsFridayDate

	Background: 
	Given I am using test data "VerifyWeekendRepaymentDayDisplayedAsFridayDateTestData.json"

@mytag
Scenario: Verify Weekend RepaymentDate Selected Displayed As Friday Date
	Given I am on the Auden Short Term loan page
	When enter weekend repayment date of 3 July 2021
	Then repayment date should be pushed back to a friday date