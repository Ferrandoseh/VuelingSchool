using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.DataAccessTier.Repository.SpecFlow.BehaviouralTests
{
    [Binding]
    public class StudentRepositorySteps
    {
        String StudentId, Name, Surname, BirthDay;
        String CreatedStudent, GotStudent;
        readonly IStudentRepository iStudentRepository = new StudentRepository();

        [Given(@"I have entered ""(.*) as StudentId")]
        public void GivenIHaveEnteredAsStudentId(string p0)
        {
            StudentId = p0;
        }
        
        [Given(@"I have entered ""(.*)"" as Name")]
        public void GivenIHaveEnteredAsName(string p0)
        {
            Name = p0;
        }
        
        [Given(@"I have entered ""(.*)"" as Surname")]
        public void GivenIHaveEnteredAsSurname(string p0)
        {
            Surname = p0;
        }
        
        [Given(@"I have entered ""(.*)"" as BirthDay")]
        public void GivenIHaveEnteredAsBirthDay(string p0)
        {
            BirthDay = p0;
        }
        
        [Given(@"I have created an written in a file a new object Student with these data")]
        public void GivenIHaveCreatedAnWrittenInAFileANewObjectStudentWithTheseData()
        {
            CreatedStudent = iStudentRepository.AddNewStudent(StudentId, Name, Surname, BirthDay).ToString();
        }
        
        [When(@"I press enter")]
        public void WhenIPressEnter()
        {
            
        }
        
        [Then(@"the string writen in the text should be the same as the last line read from this one")]
        public void ThenTheStringWritenInTheTextShouldBeTheSameAsTheLastLineReadFromThisOne()
        {
            List<Student> studentList = iStudentRepository.GetAllStudents();
            GotStudent = studentList[studentList.Count - 1].ToString();
            Assert.AreEqual(CreatedStudent, GotStudent);
        }
    }
}
