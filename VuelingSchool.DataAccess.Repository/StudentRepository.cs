using System;
using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        List<Student> studentsList = new List<Student>();

        public StudentRepository()
        {
        }

        public Student AddNewStudent(string studentId, string name, string surname, string birthday)
        {
            Student student = new Student(studentId, name, surname, birthday);
            studentsList.Add(student);
            FileManager.Add(student);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            List<string> lines = FileManager.Get();
            int numLines = lines.Count;
            for (int i = 0; i < numLines; i++)
            {
                studentsList.Add(Student.LineToStudent(lines[i]));
            }
            return studentsList;
        }
        
        public string GetStudentByName(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
