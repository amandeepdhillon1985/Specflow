#browser tag is used to intialize the driver and navigate to the url
@browser 
Feature: Products and services
	Users can find information of all the products and services


Scenario: Clicking on current account takes user to the correct page
	Given the user click on product and services tab
	When the user click on current accounts from the dropdown
	Then the user land on the correct page

Scenario: Current account page shows three products
    Given the user click on product and services tab
	When the user click on current accounts from the dropdown
	Then the user can see three current account products

Scenario: Fees for platinum account product is pounds 21 per month
    Given the user click on product and services tab
	When the user click on current accounts from the dropdown
	Then the fees of platinum accout is £21 per month