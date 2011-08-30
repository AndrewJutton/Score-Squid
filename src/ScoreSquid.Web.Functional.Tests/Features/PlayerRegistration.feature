Feature: Registration
	As a player
	I want to create an account
	So that I can join a mini league

@mytag
Scenario: Register
	Given that I do not have an existing account
	When I navigate to the registration screen
	And I enter my registration details
	Then I should successfully create an account
