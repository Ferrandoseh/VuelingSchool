using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace VuelingSchool.Presentation.WinSite
{
    sealed class ProvincesSingleton
    {
        private static ProvincesSingleton instance;
        private static readonly object _lock = new object();
        private static readonly string repositoryPath = ConfigurationManager.AppSettings.Get("provincesPath");
        public List<string> ProvinceList;
        private ProvincesSingleton()
        {
            ProvinceList = GetAll();
        }
        public static ProvincesSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new ProvincesSingleton();
                        }
                    }
                }
                return instance;
            }
        }

        private List<String> GetAll()
        {
            XDocument xmlRoot = XDocument.Load(repositoryPath);
            List<string> list = xmlRoot.Descendants("Province")
                        .Select(prov => prov.Value)
                        .ToList();
            return list;
        }
    }
}
