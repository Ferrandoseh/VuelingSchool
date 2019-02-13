using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public static class FileManager
    {
        public static bool Write(Student s)
        {
            using (StreamWriter w = File.AppendText("student.txt"))
            {
                w.WriteLine( s.get() );
            }
            return true;
        }
    }    
}
