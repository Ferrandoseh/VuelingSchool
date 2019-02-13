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

            FileManager.Write(student);
        }
    }
}
