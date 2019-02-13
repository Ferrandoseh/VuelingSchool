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
        public static void Add(Student s)
        {
            using (StreamWriter w = File.AppendText("student.txt"))
            {
                w.WriteLine(s.ToString());
            }
        }
        public static List<string> Get()
        {
            List<string> lines = new List<string>();
            string line = "";
            using (StreamReader sr = new StreamReader("student.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    lines.Add(line);
                }
            }
            return lines;
        }
        public static string GetUntilOrEmpty(ref string line)
        {
            string text = line;
            if (!String.IsNullOrWhiteSpace(text))
            { 
                int charLocation = text.IndexOf(", ", StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    line = text.Substring(charLocation+2, text.Length - (charLocation+2));
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }    
}
