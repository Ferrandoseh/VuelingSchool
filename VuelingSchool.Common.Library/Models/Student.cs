using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Models
{
    public class Student
    {
        private Guid SGuid { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }

        public Student(string StudentId, string Name, string Surname, string Birthday)
        {
            this.SGuid = Guid.NewGuid();
            this.StudentId = StudentId;
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }
        public Student()
        {
            this.SGuid = Guid.NewGuid();
        }
        public static Student ToObject(string line)
        {
            var expression = new Regex(
                String.Concat("(?<Guid>[^,]+), ", "(?<StudentId>[^,]+), ", "(?<Name>[^,]+), ",
                "(?<Surname>[^,]+), ", "(?<Birthday>[^,]+)"));
            var match = expression.Match(line);

            Student student = new Student
            {
                SGuid = new Guid(match.Groups["Guid"].ToString()),
                StudentId = match.Groups["StudentId"].ToString(),
                Name = match.Groups["Name"].ToString(),
                Surname = match.Groups["Surname"].ToString(),
                Birthday = match.Groups["Birthday"].ToString()
            };

            return student;
        }
        public override string ToString()
        {
            return String.Concat(SGuid.ToString(), ", ", StudentId, ", ", Name, ", ", Surname, ", ", Birthday);
        }
        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   SGuid.Equals(student.SGuid) &&
                   StudentId == student.StudentId &&
                   Name == student.Name &&
                   Surname == student.Surname &&
                   Birthday == student.Birthday;
        }
        public override int GetHashCode()
        {
            var hashCode = -1475940576;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(SGuid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StudentId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Birthday);
            return hashCode;
        }
    }
}
