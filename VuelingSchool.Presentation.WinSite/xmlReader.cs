using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace VuelingSchool.Presentation.WinSite
{
    sealed class XmlReader
    {
        private static XmlReader instance;
        private static object _lockThis = new object();
        private static readonly string repositoryPath = ConfigurationManager.AppSettings.Get("provincesPath");
        public static List<string> ProvinceList { get; set; }
        public static XmlReader Instance
        {
            get
            {
                lock (_lockThis)
                {
                    if (instance == null)
                    {
                        instance = new XmlReader();
                        ProvinceList = GetAll();
                    }
                }
                return instance;
            }
        }

        private static List<String> GetAll()
        {
            XDocument xmlRoot = XDocument.Load("C:/Users/ferra/source/repos/VuelingSchool/VuelingSchool.Presentation.WinSite/Provinces.xml");
            List<string> list = xmlRoot.Descendants("Province")
                        .Select(prov => prov.Value)
                        .ToList();
            return list;
        }
    }
}
