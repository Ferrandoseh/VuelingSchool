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
        /// <summary>
        /// Get Instance method
        /// Method to get the current instance of the FileManagerFactory
        /// </summary>
        /// <returns>
        /// Returns the instance of the AbstractManagerFactory already if it is
        /// already instantiated. Otherwise it creates it before returning it.
        /// </returns>
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

            string className;

            try
            {
                className = query.First().Value;
            }
            catch(ArgumentNullException e)
            {
                Log.Error(e);
                throw;
            }

            Assembly myAssembly = typeof(FileManager).Assembly;
            Type classType = myAssembly.GetType(className);

            return (FileManager)Activator.CreateInstance(classType);
        }
    }
}
