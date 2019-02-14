Feature: StudentRepository
	I want to store students properly
	Add a new Student and validate is readable later

Scenario Outline: Add new Student in a file text
	Given there is a new student
	And I have entered <studentId> as the ID
	And I have entered <name> as a name
	And I have entered <surname> as a surname
	And I have entered <birthDay> as a date of birth
	When I add this student into a file
	Then The student got is the same as the student added previously
	
	Examples:
    | studentId | name    | surname   | birthDay     |
    | "0001"    | "Marco" | "Polo"    | "01/01/2001" |
    | "0002"    | "Ana"   | "Banana"  | "01/01/2001" |
    | "0003"    | "Poco"  | "Yo"      | "01/01/2001" |
    | "0004"    | "Homer" | "Simpson" | "01/01/2001" |