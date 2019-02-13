using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingSchool.DataAccess.Repository
{
    public interface IStudentRepository
    {
        void AddNewStudent(string studentId, string name, string surname, string birthday);
    }
}
