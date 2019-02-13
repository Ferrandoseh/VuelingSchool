using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Models
{
    public class Student
    {
        private Guid SGuid { get; set; }
        public string StudentId { get; set; }
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

        public Student()
        {
        }

        public override string ToString()
        {
            return String.Concat(SGuid.ToString(), ", ", StudentId, ", ", Name, ", ", Surname, ", ", Birthday);
        }
        public static Student LineToStudent(string line)
        {
            Student student = new Student();
            student.SGuid = new Guid(FileManager.GetUntilOrEmpty(ref line));
            student.StudentId = FileManager.GetUntilOrEmpty(ref line);
            student.Name = FileManager.GetUntilOrEmpty(ref line);
            student.Surname = FileManager.GetUntilOrEmpty(ref line);
            student.Birthday = line;

            return student;
        }
        

    }
}
