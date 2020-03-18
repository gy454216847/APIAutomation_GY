Feature: Authentication
	In order to login or register for new account
	As a web client
	I need to authenticate and get the correct responses

@Authentication @Scenario_2 @RegisterUserWithExistedAccount
Scenario: Verify Post operation for registering a Existed accout
	Given I perform a RegisterUser POST operation for e-store/authentication/register with body
		| key      | value    |
		| username | username |
		| password | password |
	Then I should have the response with status code OK
	And I should save the accountNumber from the response
	When I register with same username
	Then I can not register