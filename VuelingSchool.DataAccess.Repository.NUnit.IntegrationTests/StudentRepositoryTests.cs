using NUnit.Framework;
using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository.Tests
{
    [TestFixture]
    public class StudentRepositoryTests
    {
        IStudentRepository iStudentRepository;
        Student studentAdded, lastStudent;

        [SetUp]
        public void Init()
        {
            iStudentRepository = new StudentRepository();
        }

        [TestCase("999", "Amancio", "Serra", "23/07/1996")]
        public void AddNewStudentAndGetTheStudentTest(string StudentId,
            string Name, string Surname, string Birthday)
        {
            studentAdded = iStudentRepository.AddNewStudent(StudentId, Name,
                Surname, Birthday);
            List<Student> studentList = iStudentRepository.GetAllStudents();
            lastStudent = studentList[studentList.Count-1];
            Assert.AreEqual(studentAdded.ToString(), lastStudent.ToString());
        }
    }
}