Feature: StudentRepositoryTxtManager
	I want to store students properly
	Add a Student and validate is readable later
	Delete Student
	Try to delete a Student it doesn't exist
	Get a Student
	Try to get a Student it doesn't exist
	Update a Student
	Try to update a Student it doesn't exist
	
Scenario Outline: Add Student in a file text
	Given There is a new student
	And I have entered <studentId> as the StudentId
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

	
Scenario Outline: Get a Student from a file text
	Given There is a student with the <studentId> as its StudentId
	And I have entered <studentId> as the StudentId
	When I try to get this student from the file
	Then The student got has <studentId> as its StudentId
	
	Examples:
    | studentId |
    | "0001"    |
    | "0002"    |
    | "0003"    |
    | "0004"    |
	

Scenario Outline: Get a Student from a file text when it doesn't exist
	Given There is not any student with the <studentId> as its StudentId
	And I have entered <studentId> as the StudentId
	When I try to get this student from the file
	Then The student got is null
	
	Examples:
    | studentId |
    | "1111"    |
    | "2222"    |
    | "3333"    |
    | "4444"    |
	

Scenario Outline: Delete a Student from a file text
	Given There is a student with these params
    | studentId | name    | surname   | birthDay     |
    | 0005    | Marco | Polo    | 01/01/2001 |
    | 0006    | Ana   | Banana  | 01/01/2001 |
    | 0007    | Poco  | Yo      | 01/01/2001 |
    | 0008    | Homer | Simpson | 01/01/2001 |
	And I have entered <studentId> as the StudentId
	When I delete this student from a file
	Then The result is <deleted>
	
	Examples:
    | studentId | deleted |
    | "0005"    | true    |
    | "0006"    | true    |
    | "0007"    | true    |
    | "0008"    | true    |
	

Scenario Outline: Delete a Student from a file text when it doesn't exist
	Given There is not any student with the <studentId> as its StudentId
	And I have entered <studentId> as the StudentId
	When I delete this student from a file
	Then The result is <deleted>
			
	Examples:
    | studentId | deleted |
    | "1111"    | false   |
    | "2222"    | false   |
    | "3333"    | false   |
    | "4444"    | false   |


Scenario Outline: Update a Student from a file text
	Given There is a student with the <studentId> as its StudentId
	And I have entered <studentId> as the StudentId
	And I have entered <name> as a name
	And I have entered <surname> as a surname
	And I have entered <birthDay> as a date of birth
	When I update this student in a file
	Then The student got has the parameters entered previously
	
	Examples:
    | studentId | name    | surname   | birthDay     |
    | "0009"    | "Marco" | "Polo"    | "01/01/2001" |
    | "0010"    | "Ana"   | "Banana"  | "01/01/2001" |
    | "0011"    | "Poco"  | "Yo"      | "01/01/2001" |
    | "0012"    | "Homer" | "Simpson" | "01/01/2001" |
	

Scenario Outline: Update a Student from a file text when it does not exist
	Given There is not any student with the <studentId> as its StudentId
	And I have entered <studentId> as the StudentId
	And I have entered <name> as a name
	And I have entered <surname> as a surname
	And I have entered <birthDay> as a date of birth
	When I update this student in a file
	Then The student got is a null value
	
	Examples:
    | studentId | name    | surname   | birthDay     |
    | "1111"    | "Marco" | "Polo"    | "01/01/2001" |
    | "2222"    | "Ana"   | "Banana"  | "01/01/2001" |
    | "3333"    | "Poco"  | "Yo"      | "01/01/2001" |
    | "4444"    | "Homer" | "Simpson" | "01/01/2001" |