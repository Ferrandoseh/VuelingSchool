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

        public Student AddNewStudent(Student student)
        {
            Student addedStudent = null;
            try
            {
                addedStudent = FileManager.Add(student);
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
            List<Student> studentList = null;
            try
            {
                studentList = FileManager.GetAll();
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
            List<Student> studentList = null;
            try
            {
                studentList = GetAllStudents();
                foreach (Student s in studentList)
                {
                    if (studentId.Equals(s.StudentId))
                        student = s;
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
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return student;
        }
    }
}
