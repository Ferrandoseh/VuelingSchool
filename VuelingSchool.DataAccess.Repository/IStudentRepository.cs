using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.DataAccess.Repository
{
    public interface IStudentRepository
    {
        FileManager FileManager { get; set; }

        Student AddNewStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(string studentId);
        bool DeleteStudent(string studentId);
        Student UpdateStudent(string studentId, string name, string surname, string birthday);
        
    }
}
