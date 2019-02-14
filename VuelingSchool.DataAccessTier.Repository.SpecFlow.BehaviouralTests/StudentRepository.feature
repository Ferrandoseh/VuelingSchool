Feature: StudentRepository
	I want to store Students properly
	Add a new Student and check is readable later

Scenario: Add new Student in a file text
	Given I have entered "2222" as StudentId<s
	And I have entered "Melvin" as Name
	And I have entered "BDDTest" as Surname
	And I have entered "14/02/2000" as BirthDay
	And I have created a Student with those data
	When I have added this Student into a file
	Then The Student got is the same as the Student added previously
