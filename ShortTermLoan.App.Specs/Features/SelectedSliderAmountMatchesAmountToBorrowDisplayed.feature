Feature: SelectedSliderAmountMatchesAmountToBorrow

Background: 
	Given I am using test data "VerifyMaximumLoanAmountTestData.json"

@specflow

Scenario: Selected Slider Amount Matches Amount To Borrow Displayed
	Given I am on the Auden Short Term loan page
	When move the slider to the value of 350
	Then the amount to borrow amount also displays 350