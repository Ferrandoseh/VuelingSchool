using System;
using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> studentList { get; }
        
        public StudentRepository()
        {
            studentList = GetAllStudents();
        }

        public Student AddNewStudent(Student student)
        {
            studentList.Add(student);
            return FileManager.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return FileManager.Get();
        }

        public Student GetStudentById(string studentId)
        {
            Student student = null;
            bool found = false;
            int count = studentList.Count;
            for(int i = 0; i < count && !found; i++)
            {
                Student s = studentList[i];
                if( studentId.Equals(s.StudentId) )
                {
                    found = true;
                    student = s;
                }
            }
            return student;
        }
    }
}
