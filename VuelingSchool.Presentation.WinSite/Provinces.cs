using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingSchool.Presentation.WinSite
{
    sealed class Provinces
    {
        private static Provinces instance;
        private static object _lockThis = new object();

        private Provinces() {
        }

        public static Provinces Instance
        {
            get
            {
                lock (_lockThis)
                {
                    if (instance == null)
                        instance = new Provinces();
                }
                return instance;
            }
        }
        
        public List<String> Value { get; set; }
    }

}
