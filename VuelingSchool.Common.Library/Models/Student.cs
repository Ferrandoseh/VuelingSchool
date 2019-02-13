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
        public readonly string StudentId;
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Birthday { get; set; }

        public Student (string StudentId, string Name, string Surname, string Birthday)
        {
            this.SGuid = Guid.NewGuid();
            this.StudentId = StudentId;
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }
        public override string ToString()
        {
            return String.Concat(SGuid.ToString(), ", ", StudentId, ", ", Name, ", ", Surname, ", ", Birthday);
        }

    }
}
