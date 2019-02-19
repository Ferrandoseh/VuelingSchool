using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public class XmlManager : FileManager
    {
        public override Student Add(Student o)
        {
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
        public override List<Student> GetAll()
        {
            List<Student> objects = new List<Student>();

            XmlSerializer deserializer = new XmlSerializer(typeof(Student));
            using (var xmlReader = XmlReader.Create(localPath))
            {
                String className = typeof(Student).Name;
                bool found = xmlReader.ReadToFollowing(className);
                if(found) { 
                    do
                    {
                        objects.Add( (Student)deserializer.Deserialize(xmlReader) );
                    } while (xmlReader.ReadToNextSibling(className));
                }
            }
            return objects;
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
                    if(currentObject != null && currentObject.StudentId.Equals(id) )
                        o = currentObject;
                } while (xmlReader.ReadToNextSibling(className) && o == null);
            }
            return o;
        }
        public override bool DeleteObject(string id)
        {
            bool deleted = false;
            XDocument xDoc = XDocument.Load(localPath);
            var element = xDoc.Elements("root").Elements("Student");
            foreach (var objectXml in element)
            {
                var currentId = objectXml.Elements("StudentId").Single();
                if (currentId.Value == id)
                {
                    objectXml.Remove();
                    deleted = true;
                }
            }
            xDoc.Save(localPath);
            return deleted;
        }
        public override Student UpdateObject(Student o)
        {
            Student studentGot = null;
            XDocument xDoc = XDocument.Load(localPath);
            var element = xDoc.Elements("root").Elements("Student");
            foreach (var objectXml in element)
            {
                var currentId = objectXml.Elements("StudentId").Single();
                if (currentId.Value == o.StudentId)
                {
                    var sGuid = objectXml.Elements("SGuid").Single();
                    var name = objectXml.Elements("Name").Single();
                    var surname = objectXml.Elements("Surname").Single();
                    var birthday = objectXml.Elements("Birthday").Single();
                    name.Value = o.Name;
                    surname.Value = o.Surname;
                    birthday.Value = o.Birthday;
                    studentGot = o;
                    studentGot.SGuid = new Guid(sGuid.Value);
                }
            }
            xDoc.Save(localPath);
            return studentGot;
        }
        public override void ComputeFilePath()
        {
            localPath = !string.IsNullOrEmpty(environmentPath) ?
               environmentPath : repositoryPath;
            localPath = String.Concat(localPath, "xml");
        }
        public override void CreateFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root></root>");
            using (XmlTextWriter writer = new XmlTextWriter(localPath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }
    }
}
