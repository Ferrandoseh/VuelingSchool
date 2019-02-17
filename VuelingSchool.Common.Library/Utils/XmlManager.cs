using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public class XmlManager : FileManager
    {
        public override Student Add(Student o)
        {
            if (!File.Exists(localPath))
                CreateFile();

            XmlDocument doc = new XmlDocument();
            doc.Load(localPath);
            var rootNode = doc.GetElementsByTagName("root")[0];
            var nav = rootNode.CreateNavigator();
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] {
               XmlQualifiedName.Empty
           });

            using (var writer = nav.AppendChild())
            {
                var serializer = new XmlSerializer(o.GetType());
                writer.WriteWhitespace("");
                serializer.Serialize(writer, o, emptyNamepsaces);
                writer.Close();
            }
            doc.Save(localPath);

            return GetLast();
        }

        private void CreateFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root></root>");
            using (XmlTextWriter writer = new XmlTextWriter(localPath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }

        public override List<Student> GetAll()
        {
            List<Student> objects = new List<Student>();

            XmlSerializer deserializer = new XmlSerializer(typeof(Student));
            using (var xmlReader = XmlReader.Create(localPath))
            {
                String className = typeof(Student).Name;
                xmlReader.ReadToFollowing(className);
                do
                {
                    objects.Add( (Student)deserializer.Deserialize(xmlReader) );
                } while (xmlReader.ReadToNextSibling(className));
            }
            return objects;
        }
        public override bool DeleteObject(string id)
        {
            throw new NotImplementedException();
        }

        public override Student GetLast()
        {
            List<Student> objects = GetAll();
            return objects[objects.Count-1];
        }

        public override Student GetObjectById(string id)
        {
            Student o = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(Student));
            using (var xmlReader = XmlReader.Create(localPath))
            {
                String className = typeof(Student).Name;
                xmlReader.ReadToFollowing(className);
                do
                {
                    Student currentObject = (Student)deserializer.Deserialize(xmlReader);
                    if(currentObject.StudentId.Equals(id) )
                    {
                        o = currentObject; 
                    }
                } while (xmlReader.ReadToNextSibling(className) && o == null);
            }
            return o;
        }

        public override Student UpdateObject(Student o)
        {
            throw new NotImplementedException();
        }

        public override void ComputeFilePath()
        {
            localPath = !string.IsNullOrEmpty(environmentPath) ?
               environmentPath : repositoryPath;
            localPath = String.Concat(localPath, "xml");
        }
    }
}
