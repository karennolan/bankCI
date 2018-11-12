# Gherkin DSL

Feature: Withdraw Feature
	Withdraw money from a bank account

# scenario 1
Scenario: Withdraw money when there is no overdraft facility
	Given the balance on my account is 100
	When I withdraw 75
	Then the balance on the account should be 25

# scenario 2
Scenario: Withdraw money when there is there is an overdraft facility
	Given the balance on my account is 200
	And there is an overdraft limit of 500 on the account
	When I withdraw 300
	Then the balance on the account should be -100

# generate feature step definitions and complete
# text needs to match exactly step defintion 
# text in italics are parameters