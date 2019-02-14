using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        readonly IStudentRepository iStudentRepository = new StudentRepository();

        [DataRow("9999", "Amancio", "Test", "23/07/1996")]
        [DataTestMethod()]
        public void StudentRepositoryTest(string studentId,
           string name, string surname, string birthday)
        {
            Student prevStudent = new Student(studentId, name, surname, birthday);
            Student addedStudent = iStudentRepository.AddNewStudent(prevStudent);
            Assert.AreEqual(prevStudent, addedStudent);
        }
    }
}