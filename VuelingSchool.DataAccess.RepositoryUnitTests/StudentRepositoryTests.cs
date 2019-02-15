using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        IStudentRepository mockObject;
        private Student s1, s2, sUpdated, sNull;

        [TestInitialize()]
        public void SetUp()
        {
            s1 = new Student("ut01", "Pere", "Test", "23/07/1996");
            s2 = new Student("ut02", "Fran", "Test", "23/07/1950");
            sUpdated = new Student("ut02", "Irene", "Test", "23/07/1996");
            sNull = null;

            var mock = new Mock<IStudentRepository>();
            mock.Setup(x => x.AddNewStudent(s1)).Returns(s1);
            mock.Setup(x => x.GetStudentById("ut02")).Returns(s2);
            mock.Setup(x => x.GetStudentById("ut00")).Returns(sNull);
            mock.Setup(x => x.DeleteStudent("ut02")).Returns(true);
            mock.Setup(x => x.DeleteStudent("ut00")).Returns(false);
            mock.Setup(x => x.UpdateStudent("ut02", "Irene", "Test", "23/07/1996")).Returns(sUpdated);
            mock.Setup(x => x.UpdateStudent("ut00", "Marco", "Test", "23/07/1950")).Returns(sNull);
            mockObject = mock.Object;
        }

        [TestMethod()]
        public void AddNewStudentTest()
        {
            Assert.AreEqual(s1, mockObject.AddNewStudent(s1));
        }

        [TestMethod()]
        public void GetStudentByIdTest()
        {
            Assert.AreEqual(s2, mockObject.GetStudentById("ut02"));
        }

        [TestMethod()]
        public void GetStudentByIdWhenDoesNotExistAnyTest()
        {
            Assert.AreEqual(sNull, mockObject.GetStudentById("ut00"));
        }

        [TestMethod()]
        public void DeleteStudentByIdTest()
        {
            Assert.AreEqual(true, mockObject.DeleteStudent("ut02"));
        }

        [TestMethod()]
        public void DeleteStudentByIdWhenDoesNotExistAnyTest()
        {
            Assert.AreEqual(false, mockObject.DeleteStudent("ut00"));
        }

        [TestMethod()]
        public void UpdateStudentByIdTest()
        {
            Assert.AreEqual(sUpdated, mockObject.UpdateStudent("ut02", "Irene", "Test", "23/07/1996"));
        }

        [TestMethod()]
        public void UpdateStudentByIdWhenDoesNotExistAnyTest()
        {
            Assert.AreEqual(sNull, mockObject.UpdateStudent("ut00", "Marco", "Test", "23/07/1950"));
        }
    }
}