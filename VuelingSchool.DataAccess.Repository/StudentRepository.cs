using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AddNewStudent(string studentId, string name, string surname, string birthday)
        {
            Student student = new Student(studentId, name, surname, birthday);
            studentsList.Add(student);
            FileManager.Add(student);
        }

        public String GetAllStudents()
        {
            List<string> lines = FileManager.Get();
            int numLines = lines.Count;
            for (int i = 0; i < numLines; i++)
            {
                studentsList.Add(Student.LineToStudent(lines[i]));
            }
            return StudentListToString( ref studentsList );
        }

        private string StudentListToString(ref List<Student> studentsList)
        {
            string result = "";
            for(int i = 0; i< studentsList.Count; i++)
            {
                result = String.Concat(result, studentsList[i].ToString(), "\n");
            }
            return result;
        }

        public string GetStudentByName(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
