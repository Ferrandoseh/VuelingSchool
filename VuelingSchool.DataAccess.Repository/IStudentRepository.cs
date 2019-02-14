using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository
{
    public interface IStudentRepository
    {
        Student AddNewStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(string studentId);
    }
}
