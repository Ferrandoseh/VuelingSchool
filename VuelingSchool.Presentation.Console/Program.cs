using System;
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
            string optionSelected = null;
            while (true)
            {
                System.Console.WriteLine("\n\nAcciones a realizar:");
                System.Console.WriteLine("\t 1. Add new student");
                System.Console.WriteLine("\t 2. Show all students");
                System.Console.WriteLine("\t 3. Exit");
                optionSelected = System.Console.ReadLine();
                System.Console.WriteLine("You entered '{0}'", optionSelected);
                
                StudentRepository sr = new StudentRepository();
                if (optionSelected.Equals("1"))
                    GetStudentParams(sr);
                else if (optionSelected.Equals("2"))
                    ShowStudents(sr);
                else
                    Environment.Exit(0);
            }
        }
        private static void ShowStudents(StudentRepository sr)
        {
            System.Console.Write( sr.GetAllStudents() );
        }

        private static void GetStudentParams(StudentRepository sr)
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

            sr.AddNewStudent(StudentId, Name, Surname, Birthday);
        }
    }
}
