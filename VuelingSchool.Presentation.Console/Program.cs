using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SelectOption();
        }
        
        public static void SelectOption()
        {
            int optionSelected;
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Acciones a realizar:");
                System.Console.WriteLine("\t 1. Add new student");
                System.Console.WriteLine("\t 2. Exit");
                optionSelected = Convert.ToInt32(System.Console.ReadLine());
                System.Console.WriteLine("You entered '{0}'", optionSelected);
                if (optionSelected == 1)
                    GetStudentParams();
                else
                    Environment.Exit(0);
            }
        }
        private static void GetStudentParams()
        {
            string StudentId, Name, Surname, Birthday;
            System.Console.WriteLine("\nADD NEW STUDENT");
            System.Console.Write("\tType the StudentId: ");
            StudentId = System.Console.ReadLine();
            System.Console.Write("\tType the name: ");
            Name = System.Console.ReadLine();
            System.Console.Write("\tType the surname: ");
            Surname = System.Console.ReadLine();
            System.Console.Write("\tType the birth date (dd/mm/yyyy): ");
            Birthday = System.Console.ReadLine();

            StudentRepository sr = new StudentRepository();
            sr.AddNewStudent(StudentId, Name, Surname, Birthday);
        }
    }
}
