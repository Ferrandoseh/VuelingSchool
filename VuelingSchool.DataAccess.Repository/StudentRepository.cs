using System;
using System.Collections.Generic;
using System.IO;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected static readonly log4net.ILog Log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FileManager FileManager { get; set; }

        public StudentRepository(FileManager fileManager) => this.FileManager = fileManager;
        public Student AddNewStudent(Student student)
        {
            Student addedStudent = null;
            try
            {
                addedStudent = FileManager.Add(student);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return addedStudent;
        }
        public List<Student> GetAllStudents()
        {
            List<Student> studentList;
            try
            {
                studentList = FileManager.GetAll();
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return studentList;
        }
        public Student GetStudentById(string studentId)
        {
            Student student = null;
            try
            {
                student = FileManager.GetObjectById(studentId);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return student;
        }
        public bool DeleteStudent(string studentId)
        {
            bool deletedStudent = false;
            try
            {
                deletedStudent = FileManager.DeleteObject(studentId);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return deletedStudent;
        }
        public Student UpdateStudent(string studentId, string name, string surname, string birthday)
        {
            Student updatedStudent = null;
            try
            {
                Student prevStudent = FileManager.GetObjectById(studentId);
                if (prevStudent != null) {
                    prevStudent.StudentId = studentId;
                    prevStudent.Name = name;
                    prevStudent.Surname = surname;
                    prevStudent.Birthday = birthday;
                    updatedStudent = FileManager.UpdateObject(prevStudent);
                }
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return updatedStudent;
        }
    }
}
