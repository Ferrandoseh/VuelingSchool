﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingSchool.Common.Library.Factory;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.DataAccess.RepositoryXml.IntegrationTests
{
    [TestClass()]
    public class StudentRepositoryXmlManager
    {
        XmlManager xmlManager;
        IStudentRepository iStudentRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            xmlManager = new XmlManager();
            iStudentRepository = new StudentRepository(xmlManager);
            xmlManager.CreateFile();
        }

        [DataRow("it01", "Amancio", "Test", "23/07/1996")]
        [DataTestMethod()]
        public void AddStudentTest(string studentId,
           string name, string surname, string birthday)
        {
            Student prevStudent = new Student(studentId, name, surname, birthday);
            Student addedStudent = iStudentRepository.AddNewStudent(prevStudent);
            Assert.AreEqual(prevStudent, addedStudent);
        }

        [DataRow("it02", "Carmen", "Test", "23/07/1996")]
        [DataTestMethod()]
        public void DeleteStudentByIdTest(string studentId,
           string name, string surname, string birthday)
        {
            Student prevStudent = new Student(studentId, name, surname, birthday);
            iStudentRepository.AddNewStudent(prevStudent);
            Assert.IsTrue(iStudentRepository.DeleteStudent(studentId));
        }

        [DataRow("it03")]
        [DataTestMethod()]
        public void DeleteStudentByIdWhenDoesNotExistAnyTest(string studentId)
        {
            Assert.IsFalse(iStudentRepository.DeleteStudent(studentId));
        }

        [DataRow("it04", "Carmen", "Test", "23/07/1996")]
        [DataTestMethod()]
        public void GetStudentByIdTest(string studentId,
           string name, string surname, string birthday)
        {

            Student prevStudent = new Student(studentId, name, surname, birthday);
            iStudentRepository.AddNewStudent(prevStudent);
            Student studentGot = iStudentRepository.GetStudentById(studentId);
            Assert.AreEqual(prevStudent, studentGot);
        }
        
        [DataRow("it05")]
        [DataTestMethod()]
        public void GetStudentByIdWhenDoesNotExistAnyTest(string studentId)
        {
            Student studentGot = iStudentRepository.GetStudentById(studentId);
            Assert.IsNull(studentGot);
        }

        [DataRow("it06", "Carmen", "Test", "23/07/1996", "Elena")]
        [DataTestMethod()]
        public void UpdateStudentByIdTest(string studentId,
           string name, string surname, string birthday, string nameUpdated)
        {
            Student prevStudent = new Student(studentId, name, surname, birthday);
            Assert.AreNotEqual(prevStudent, iStudentRepository.UpdateStudent(studentId, nameUpdated, surname, birthday));
        }

        [DataRow("it07", "Elena", "Test", "23/07/1996")]
        [DataTestMethod()]
        public void UpdateStudentByIdWhenDoesNotExistAnyTest(string studentId,
           string name, string surname, string birthday)
        {
            Assert.IsNull(iStudentRepository.UpdateStudent(studentId, name, surname, birthday));
        }
    }
}
