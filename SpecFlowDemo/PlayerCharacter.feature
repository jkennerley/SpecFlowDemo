Feature: PlayerCharacter
	In order to play game 
	As a palyer
	I want player attibutes to be correctly represented


Scenario: Taking no damage when hit does not affect health
	Given a new player
	When I take 0 damage
	Then My health should be 100

