using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{
    public class FileManagerFactory : AbstractManagerFactory
    {
        public static FileManagerFactory Instance
        {
            get
            {
                if (managerFactory == null)
                    managerFactory = new FileManagerFactory();
                return (FileManagerFactory)managerFactory;
            }
        }

        public override FileManager CreateFileManager(string fileType)
        {
            XElement root = XElement.Load("./FileManagerReflection.xml");
            IEnumerable<XElement> query =
                from element in root.Elements("Type")
                where (string)element.Attribute("Id") == fileType
                select element;

            string className = query.First().Value;
            Assembly myAssembly = typeof(FileManager).Assembly;
            Type classType = myAssembly.GetType(className);
            
            return (FileManager)Activator.CreateInstance(classType);
        }
    }
}
