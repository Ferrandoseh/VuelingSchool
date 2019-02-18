using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public class JsonManager : FileManager
    {
        public override Student Add(Student o)
        {
            List<Student> objects;
            Student addedStudent;
            try
            {
                objects = GetAll();
                objects.Add(o);
                string newJson = JsonConvert.SerializeObject(objects, Formatting.Indented);
                File.WriteAllText(localPath, newJson);
                addedStudent = GetLast();
            }
            catch (UnauthorizedAccessException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (SecurityException e)
            {
                Log.Error(e.Message);
                throw;
            }

            return addedStudent;
        }
        public override List<Student> GetAll()
        {
            List<Student> objects;
            try
            {
                string json = File.ReadAllText(localPath);
                objects = JsonConvert.DeserializeObject<List<Student>>(json);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return objects;
        }
        public override Student GetLast()
        {
            List<Student> lines;
            try { 
                lines = GetAll();
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return lines[lines.Count - 1];
        }
        public override Student GetObjectById(string id)
        {
            Student o = null;
            try
            {
                List<Student> objects = GetAll();
                foreach (Student lineObject in objects )
                {
                    if (lineObject.StudentId.Equals(id))
                        o = lineObject;
                }
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return o;
        }
        public override bool DeleteObject(string id)
        {
            bool deleted = false;
            try
            {
                List<Student> prevObjects = GetAll();
                List<Student> objects = new List<Student>();
                foreach (Student lineObject in prevObjects)
                {
                    if (!lineObject.StudentId.Equals(id))
                        objects.Add(lineObject);
                    else
                        deleted = true;
                }
                string result = JsonConvert.SerializeObject(objects);
                File.WriteAllText(localPath, result);
            }
            catch (SecurityException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                Log.Error(e.Message);
                throw;
            }

            return deleted;
        }
        public override Student UpdateObject(Student o)
        {
            Student updated = null;
            try
            {
                List<Student> objects = GetAll();
                foreach (Student lineObject in objects)
                {
                    String id = o.StudentId;
                    if (lineObject.StudentId.Equals(id))
                    {
                        lineObject.Name = o.Name;
                        lineObject.Surname = o.Surname;
                        lineObject.Birthday = o.Birthday;
                        updated = lineObject;
                    }
                }
                string result = JsonConvert.SerializeObject(objects);
                File.WriteAllText(localPath, result);
            }
            catch (SecurityException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return updated;
        }
        public override void ComputeFilePath()
        {
            localPath = !string.IsNullOrEmpty(environmentPath) ?
               environmentPath : repositoryPath;
            localPath = String.Concat(localPath, "json");
        }
        public override void CreateFile()
        {
            using (StreamWriter w = File.CreateText(localPath))
            {
                w.WriteLine("[]");
            }
        }
    }
}
