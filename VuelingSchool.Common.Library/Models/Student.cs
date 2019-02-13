using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingSchool.Common.Library.Models
{
    public class Student
    {
        private readonly Guid SGuid;
        private readonly string StudentId;
        private readonly string Name;
        private readonly string Surname;
        private readonly string Birthday;

        public Student (string StudentId, string Name, string Surname, string Birthday)
        {
            this.SGuid = Guid.NewGuid();
            this.StudentId = StudentId;
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }

        public string get()
        {
            return String.Concat(SGuid.ToString(), ", ", StudentId, ", ", Name, ", ", Surname, ", ", Birthday);
        }

    }
}
