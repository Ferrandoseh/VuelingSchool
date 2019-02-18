using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.DataAccessTier.RepositoryJson.BehaviouralTests
{
    [Binding]
    public class StudentRepositoryJsonManagerSteps
    {
        private readonly IStudentRepository studentRepository = new StudentRepository (new JsonManager() );
        private Student prevStudent, studentGot;
        string studentId;
        private bool result;

        [Given(@"There is a new student")]
        public void GivenThereIsANewStudent()
        {
            prevStudent = new Student();
        }

        [Given(@"I have entered ""(.*)"" as the StudentId")]
        public void GivenIHaveEnteredAsTheStudentId(string p0)
        {
            if (prevStudent == null)
                prevStudent = new Student();
            prevStudent.StudentId = p0;
            studentId = p0;
        }

        [Given(@"I have entered ""(.*)"" as a name")]
        public void GivenIHaveEnteredAsAName(string p0)
        {
            prevStudent.Name = p0;
        }

        [Given(@"I have entered ""(.*)"" as a surname")]
        public void GivenIHaveEnteredAsASurname(string p0)
        {
            prevStudent.Surname = p0;
        }

        [Given(@"I have entered ""(.*)"" as a date of birth")]
        public void GivenIHaveEnteredAsADateOfBirth(string p0)
        {
            prevStudent.Birthday = p0;
        }

        [Given(@"There is a student with the ""(.*)"" as its StudentId")]
        public void GivenThereIsAStudentWithTheAsItsStudentId(string p0)
        {
            prevStudent = new Student
            {
                StudentId = p0,
                Name = "name",
                Surname = "surname",
                Birthday = "dd/mm/yyyy"
            };
            prevStudent = studentRepository.AddNewStudent(prevStudent);
        }

        [Given(@"There is not any student with the ""(.*)"" as its StudentId")]
        public void GivenThereIsNotAnyStudentWithTheAsItsStudentId(string p0)
        {
            prevStudent = (studentRepository.GetStudentById(p0));
            Assert.IsNull(prevStudent);
        }

        [Given(@"There is a student with these params")]
        public void GivenThereIsAStudentWithTheseParams(Table table)
        {
            int count = table.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Student s = new Student(
                    table.Rows[i]["studentId"],
                    table.Rows[i]["name"],
                    table.Rows[i]["surname"],
                    table.Rows[i]["birthDay"]
                );
                studentRepository.AddNewStudent(s);
            }
        }

        [When(@"I add this student into a file")]
        public void WhenIAddThisStudentIntoAFile()
        {
            studentGot = studentRepository.AddNewStudent(prevStudent);
        }

        [When(@"I try to get this student from the file")]
        public void WhenITryToGetThisStudentFromTheFile()
        {
            studentGot = studentRepository.GetStudentById(studentId);
        }

        [When(@"I delete this student from a file")]
        public void WhenIDeleteThisStudentFromAFile()
        {
            result = studentRepository.DeleteStudent(prevStudent.StudentId);
        }

        [When(@"I update this student in a file")]
        public void WhenIUpdateThisStudentInAFile()
        {
            studentGot = studentRepository.UpdateStudent(
                prevStudent.StudentId, prevStudent.Name, prevStudent.Surname, prevStudent.Birthday);
        }

        [Then(@"The student got is the same as the student added previously")]
        public void ThenTheStudentGotIsTheSameAsTheStudentAddedPreviously()
        {
            Assert.AreEqual(prevStudent, studentGot);
        }

        [Then(@"The student got has ""(.*)"" as its StudentId")]
        public void ThenTheStudentGotHasAsItsStudentId(string p0)
        {
            Assert.AreEqual(studentId, studentGot.StudentId);
        }

        [Then(@"The student got is null")]
        public void ThenTheStudentGotIsNull()
        {
            Assert.IsNull(studentGot);
        }

        [Then(@"The result is true")]
        public void ThenTheResultIsTrue()
        {
            Assert.IsTrue(result);
        }

        [Then(@"The result is false")]
        public void ThenTheResultIsFalse()
        {
            Assert.IsFalse(result);
        }

        [Then(@"The student got has the parameters entered previously")]
        public void ThenTheStudentGotHasTheParametersEnteredPreviously()
        {
            Assert.AreEqual(prevStudent.StudentId, studentGot.StudentId);
            Assert.AreEqual(prevStudent.Name, studentGot.Name);
            Assert.AreEqual(prevStudent.Surname, studentGot.Surname);
            Assert.AreEqual(prevStudent.Birthday, studentGot.Birthday);
        }

        [Then(@"The student got is a null value")]
        public void ThenTheStudentGotIsANullValue()
        {
            Assert.IsNull(studentGot);
        }
    }
}
