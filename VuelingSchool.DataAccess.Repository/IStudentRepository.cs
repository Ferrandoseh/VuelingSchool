using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository
{
    public interface IStudentRepository
    {
        Student AddNewStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(string studentId);
        Student UpdateStudent(string studentId, string name, string surname, string birthday);
        bool DeleteStudent(string studentId);
    }
}
