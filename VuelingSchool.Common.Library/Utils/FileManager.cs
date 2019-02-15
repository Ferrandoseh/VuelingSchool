using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public static class FileManager
    {
        private static readonly string repositoryPath = ConfigurationManager.AppSettings.Get("localPath");
        private static readonly string environmentPath = Environment.GetEnvironmentVariable("localPath",
            EnvironmentVariableTarget.User);
        private static readonly string localPath = !string.IsNullOrEmpty(environmentPath) ? 
            environmentPath : repositoryPath;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Student Add(Student student)
        {       
            try
            {
                using (StreamWriter w = File.AppendText(localPath))
                {
                    w.WriteLine(student.ToString());
                }
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                log.Error(e.Message);
                throw;
            }
            return GetLast();
        }
        private static Student GetLast()
        {
            List<Student> lines = null;
            try
            {
                lines =  GetAll();
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }

            return lines[lines.Count - 1];            
        }
        public static List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader(localPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        students.Add( Student.LineToObject(line) );
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            return students;
        }
    }    
}
