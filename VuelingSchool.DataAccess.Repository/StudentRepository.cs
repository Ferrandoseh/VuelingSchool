using System;
using System.Collections.Generic;
using System.IO;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FileManager fileManager;

        public StudentRepository(FileManager fileManager) => this.fileManager = fileManager;

        public Student AddNewStudent(Student student)
        {
            Student addedStudent = null;
            try
            {
                addedStudent = fileManager.Add(student);
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return addedStudent;
        }
        public List<Student> GetAllStudents()
        {
            List<Student> studentList;
            try
            {
                studentList = fileManager.GetAll();
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return studentList;
        }
        public Student GetStudentById(string studentId)
        {
            Student student = null;
            try
            {
                student = fileManager.GetObjectById(studentId);
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return student;
        }

        public bool DeleteStudent(string studentId)
        {
            bool deletedStudent = false;
            try
            {
                deletedStudent = fileManager.DeleteObject(studentId);
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return deletedStudent;
        }

        public Student UpdateStudent(string studentId, string name, string surname, string birthday)
        {
            Student updatedStudent = null;
            try
            {
                Student prevStudent = fileManager.GetObjectById(studentId);
                if (prevStudent != null) {
                    prevStudent.StudentId = studentId;
                    prevStudent.Name = name;
                    prevStudent.Surname = surname;
                    prevStudent.Birthday = birthday;
                    updatedStudent = fileManager.UpdateObject(prevStudent);
                }
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return updatedStudent;
        }
    }
}
