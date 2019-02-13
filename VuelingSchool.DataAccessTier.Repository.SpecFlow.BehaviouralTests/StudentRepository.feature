Feature: StudentRepository
	I want to store Students
	Add a new Student and check the data written in the file has the right name

@mytag
Scenario: Add new Student in a file text
	Given I have entered "999" as StudentId
	And I have entered "Ferran" as Name
	And I have entered "Ramirez" as Surname
	And I have entered "30/12/1993" as BirthDay
	And I have created an written in a file a new object Student with these data
	When I press enter
	Then the string writen in the text should be the same as the last line read from this one
