using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.DataAccessTier.Repository.SpecFlow.BehaviouralTests
{
    [Binding]
    public class StudentRepositorySteps
    {
        private readonly StudentRepository studentRepository = new StudentRepository();
        Student prevStudent = null, addedStudent = null;

        [Given(@"there is a new student")]
        public void GivenThereIsANewStudent()
        {
            prevStudent = new Student();
        }
        
        [Given(@"I have entered (.*) as the ID")]
        public void GivenIHaveEnteredAsTheID(string p0)
        {
            prevStudent.StudentId = p0;
        }
        
        [Given(@"I have entered (.*) as a name")]
        public void GivenIHaveEnteredAsAName(string p0)
        {
            prevStudent.Name = p0;
        }
        
        [Given(@"I have entered (.*) as a surname")]
        public void GivenIHaveEnteredAsASurname(string p0)
        {
            prevStudent.Surname = p0;
        }
        
        [Given(@"I have entered (.*) as a date of birth")]
        public void GivenIHaveEnteredAsADateOfBirth(string p0)
        {
            prevStudent.Birthday = p0;
        }
        
        [When(@"I add this student into a file")]
        public void WhenIAddThisStudentIntoAFile()
        {
            addedStudent = studentRepository.AddNewStudent(prevStudent);
        }
        
        [Then(@"The student got is the same as the student added previously")]
        public void ThenTheStudentGotIsTheSameAsTheStudentAddedPreviously()
        {
            Assert.AreEqual(prevStudent, addedStudent);
        }
    }
}
