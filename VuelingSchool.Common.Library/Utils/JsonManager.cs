using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public class JsonManager : FileManager
    {
        public override Student Add(Student o)
        {
            if( !File.Exists(localPath))
                CreateFile();

            List<Student> objects = GetAll();
            objects.Add(o);

            string newJson = JsonConvert.SerializeObject(objects, Formatting.Indented);
            File.WriteAllText(localPath, newJson);

            return GetLast();
        }

        private void CreateFile()
        {
            using (StreamWriter w = File.AppendText(localPath))
            {
                w.WriteLine("[]");
            }
        }

        public override List<Student> GetAll()
        {
            string json = File.ReadAllText(localPath);
            List<Student> objects = JsonConvert.DeserializeObject<List<Student>>(json);
            return objects;
        }

        public override bool DeleteObject(string id)
        {
            bool deleted = false;
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
            return deleted;
        }

        public override Student GetLast()
        {
            List<Student> lines = GetAll();
            return lines[lines.Count - 1];
        }

        public override Student GetObjectById(string id)
        {
            Student o = null;
            List<Student> objects = GetAll();
            foreach (Student lineObject in objects )
            {
                if (lineObject.StudentId.Equals(id))
                    o = lineObject;
            }
            return o;
        }

        public override Student UpdateObject(Student o)
        {
            Student updated = null;
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
            return updated;
        }
        public override void ComputeFilePath()
        {
            localPath = !string.IsNullOrEmpty(environmentPath) ?
               environmentPath : repositoryPath;
            localPath = String.Concat(localPath, "json");
        }
    }
}
