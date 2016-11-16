Feature: PlayerCharacter
	In order to play
	As palyer 
	I want correct character attributes

Background: 
	Given I am new player

Scenario Outline: Health reduction
	When When I take <damage> damage
	Then my health should be <expectedHealth>
	Examples: 
		| damage | expectedHealth  |
		| 0      | 100             |
		| 40     | 60              |
		| 50     | 50              |

Scenario: taking too much damage results in player death
	When I take 100 damage
	Then I should be dead

Scenario: Elf race characters get additional 20 damage resistance
	And I have damage resistence of 10 
	And I am an Elf
	When I take 40 damage
	Then my health should now be 90

Scenario: Elf race characters get additional 20 damage resistance using data table
	And I have the following attributes
		| attribute  | value  |
		| Race       | Elf    |
		| Resistence | 10     |
	When I take 40 damage
	Then my health should now be 90

Scenario: Healers restore all health
	Given My character class is set to Healer
	When I take 40 damage
		And Cast a healing spell
	Then my health should now be 100

Scenario: Total magical power
	Given I have the following magical items
	| name   | value | power |
	| Ring   | 200   | 100   |
	| Amulet | 400   | 200   |
	| Gloves | 100   | 400   |
	Then my total magica power should be 700

Scenario: reading a restore health scroll when over tired has no effect
	Given I last slept 3 days ago
	When I take 40 damage 
		And  read a restore health scroll
	Then my health should now be 60 

Scenario: weapons are worth money
	Given I have the following weapons
	| name    | value | 
	| Sword   | 50    | 
	| Pick    | 40    | 
	| Knife   | 10    | 
	Then my weapons should be worth 100

Scenario: Elf race characters don't lose magical item power
	Given I'm an elf
		And I have an amulet with a power of 200 
	When I use a magical Amulet 
	Then the amulet power should not be reduced

