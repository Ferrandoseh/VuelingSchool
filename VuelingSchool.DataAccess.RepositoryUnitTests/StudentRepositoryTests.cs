using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VuelingSchool.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingSchool.DataAccess.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        private IStudentRepository mockObject;

        [TestInitialize()]
        public void SetUp()
        {
            var mock = new Mock<IStudentRepository>();
            mock.Setup(x => x.GetStudentName(1)).Returns("Ferran");
            mock.Setup(x => x.GetStudentName(2)).Returns("Marti");
            mockObject = mock.Object;
        }

        [TestMethod()]
        public void GetStudentNameTest()
        {
            var result = mockObject.GetStudentName(1);
            Assert.AreEqual("Ferran", result);
        }
    }
}