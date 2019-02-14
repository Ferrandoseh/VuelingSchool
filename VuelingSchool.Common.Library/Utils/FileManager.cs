using System.Collections.Generic;
using System.Configuration;
using System.IO;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public static class FileManager
    {
        private static readonly string localPath = ConfigurationManager.AppSettings["localPath"];
        
        public static Student Add(Student student)
        {            
            using (StreamWriter w = File.AppendText(localPath))
            {
                w.WriteLine( student.ToString() );
            }
            return GetLastStudent();
        }
        private static Student GetLastStudent()
        {
            List<Student> lines =  Get();
            return lines[lines.Count - 1];
        }
        public static List<Student> Get()
        {
            List<Student> students = new List<Student>();
            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader(localPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        students.Add( Student.LineToStudent(line) );
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                System.Console.Write(e.Message);
                System.Console.Read();
            }
            return students;
        }
    }    
}
