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
        String studentId, name, surname, birthDay;
        [Given(@"I have entered ""(.*)"" as StudentId<s")]
        public void GivenIHaveEnteredAsStudentIdS(string p0)
        {
            studentId = p0;
        }

        [Given(@"I have entered ""(.*)"" as Name")]
        public void GivenIHaveEnteredAsName(string p0)
        {
            name = p0;
        }

        [Given(@"I have entered ""(.*)"" as Surname")]
        public void GivenIHaveEnteredAsSurname(string p0)
        {
            surname = p0;
        }

        [Given(@"I have entered ""(.*)"" as BirthDay")]
        public void GivenIHaveEnteredAsBirthDay(string p0)
        {
            birthDay = p0;
        }

        [Given(@"I have created a Student with those data")]
        public void GivenIHaveCreatedAStudentWithThoseData()
        {
            prevStudent = new Student("1", "1", "1", "1");
        }

        [When(@"I have added this Student into a file")]
        public void GivenIHaveAddedThisStudentIntoAFile()
        {
            addedStudent = studentRepository.AddNewStudent(prevStudent);
        }

        [Then(@"The Student got is the same as the Student added previously")]
        public void ThenTheStudentGotIsTheSameAsTheStudentAddedPreviously()
        {
            Assert.AreEqual(prevStudent, addedStudent);
        }
    }
}
