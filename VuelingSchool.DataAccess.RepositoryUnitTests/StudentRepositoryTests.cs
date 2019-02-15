using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        private Student student;

        [TestInitialize()]
        public void SetUp()
        {
            student = new Student("12345678", "Unit", "Test", "23/07/1996");
            IStudentRepository mockObject;
            var mock = new Mock<IStudentRepository>();
            mock.Setup(x => x.AddNewStudent(student)).Returns(student);
            mockObject = mock.Object;
        }

        [TestMethod()]
        public void AddNewStudentTest()
        {
            Assert.AreEqual(student, student);
        }
    }
}