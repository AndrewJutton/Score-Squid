Feature: Login
	As a player
	I want to be able to login
	So that I can access my account

@mytag
Scenario: Login
	Given that I have an existing account
	When I enter valid login details
	And I submit my login request
	Then I should gain access to my account
