using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public class TxtManager : FileManager
    {
        public override Student Add(Student o)
        {       
            try
            {
                using (StreamWriter w = File.AppendText(localPath))
                {
                    w.WriteLine(o.ToString());
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
        public override Student GetLast()
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

        public override Student GetObjectById(string id)
        {
            Student o = null;
            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader(localPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Student lineObject = Student.ToObject(line);
                        if (lineObject.StudentId.Equals(id))
                            o = lineObject;
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
            return o;
        }

        public override bool DeleteObject(string id)
        {
            bool found = false;
            try
            {
                string line = "";
                int lineToEdit = 0;
                using (StreamReader sr = new StreamReader(localPath))
                {
                    while ((line = sr.ReadLine()) != null && !found)
                    {
                        Student lineObject = Student.ToObject(line);
                        if (lineObject.StudentId.Equals(id))
                            found = true;
                        else
                            lineToEdit++;
                    }
                }
                if (found)
                {
                    string[] lines = File.ReadAllLines(localPath);
                    using (StreamWriter writer = new StreamWriter(localPath))
                    {
                        int length = lines.Length;
                        for (int i = 0; i < length; i++)
                        {
                            if (i != lineToEdit)
                                writer.WriteLine(lines[i]);
                        }
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
            return found;
        }

        public override Student UpdateObject(Student o)
        {
            Student updated = null;
            try
            {
                bool found = false;
                string line = "";
                int lineToEdit = 0;

                using (StreamReader sr = new StreamReader(localPath))
                {
                    while ((line = sr.ReadLine()) != null && !found)
                    {
                        Student lineObject = Student.ToObject(line);
                        string studentId = o.StudentId;
                        if (lineObject.StudentId.Equals(studentId))
                            found = true;
                        else
                            lineToEdit++;
                    }
                }
                if(found)
                {
                    updated = o;
                    string[] lines = File.ReadAllLines(localPath);
                    using (StreamWriter writer = new StreamWriter(localPath))
                    {
                        int length = lines.Length;
                        for (int i = 0; i < length; i++)
                        {
                            if (i == lineToEdit)
                                writer.WriteLine(o.ToString());
                            else
                                writer.WriteLine(lines[i]);
                        }
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
            return updated;
        }

        public override List<Student> GetAll()
        {
            List<Student> objects = new List<Student>();
            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader(localPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        objects.Add( Student.ToObject(line) );
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
            return objects;
        }

        public override void ComputeFilePath()
        {
            localPath = !string.IsNullOrEmpty(environmentPath) ?
               environmentPath : repositoryPath;
            localPath = String.Concat(localPath, "txt");
        
            if (!File.Exists(localPath))
                CreateFile();
        }
        private void CreateFile()
        {
            StreamWriter w = File.CreateText(localPath);
            w.Close();
            w.Dispose();
        }
    }    
}
