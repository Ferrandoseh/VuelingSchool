using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public static class FileManager
    {
        private static readonly string localPath = ConfigurationManager.AppSettings["localPath"];
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Student Add(Student student)
        {         
            try
            {
                using (StreamWriter w = File.AppendText(localPath))
                {
                    w.WriteLine( student.ToString() );
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
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
                log.Error(e.Message);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return students;
        }

        public static void ThrowException()
        {
            log.Error("Error trying to do something");
            try
            {
                throw new NotImplementedException();
            }
            catch (NotImplementedException e)
            {
                log.Error(e);
            }
        }
    }    
}
