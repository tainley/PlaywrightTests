Feature: Navigation

As a user
I want to easily navigate the website
So I can find what I want quickly

@tag1
Scenario: Navigation
	Given I am on the homepage
	When I click on the Get Started link
	Then I should see the Installation page