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
            try
            {
                using (StreamWriter w = File.AppendText("C:/Users/ferra/source/repos/VuelingSchool/student.txt"))
                {
                    w.WriteLine(s.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("An error ocurred while trying to add data: {0}", e.Message), e);
            }
        }
        public static List<string> Get()
        {
            List<string> lines = new List<string>();
            string line = "";
            try {
                using (StreamReader sr = new StreamReader("C:/Users/ferra/source/repos/VuelingSchool/student.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("An error ocurred while trying to get data: {0}", e.Message), e);
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
