using System;
using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            SelectOption();
        }
        
        public static void SelectOption()
        {
            string caseSwitch = null;
            while (true)
            {
                System.Console.WriteLine("\n\nAcciones a realizar:");
                System.Console.WriteLine("\t 1. Add new student");

                System.Console.WriteLine("\t 2. Show all students");
                System.Console.WriteLine("\t 3. Get student by id");
                System.Console.WriteLine("\t 4. Throw an exception");
                System.Console.WriteLine("\t . Exit");
                caseSwitch = System.Console.ReadLine();
                System.Console.WriteLine("You entered '{0}'", caseSwitch);
                
                StudentRepository sr = new StudentRepository();
                
                switch (caseSwitch)
                {
                    case "1":
                        GetStudentParams(sr);
                        break;
                    case "2":
                        ShowStudents(sr);
                        break;
                    case "3":
                        ShowStudent(sr);
                        break;
                    case "4":
                        ThrowException();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }                    
            }
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

            Student student = new Student(StudentId, Name, Surname, Birthday);
            sr.AddNewStudent(student);
        }
        private static void ShowStudents(StudentRepository sr)
        {
            StudentListToString(sr.GetAllStudents());
        }
        private static void ShowStudent(StudentRepository sr)
        {
            string studentId;
            System.Console.Write("\t Enter Student Id: ");
            studentId = System.Console.ReadLine();
            Student student = sr.GetStudentById(studentId);
            if (student == null)
                System.Console.WriteLine("There's not any Student with such StudentId");
            else
                System.Console.WriteLine(student.ToString());
        }
        private static void ThrowException()
        {
            FileManager.ThrowException();
        }

        private static void StudentListToString(List<Student> studentsList)
        {
            string result = "";
            for (int i = 0; i < studentsList.Count; i++)
            {
                result = String.Concat(result, studentsList[i].ToString(), "\n");
            }
            System.Console.WriteLine(result);
        }
    }
}
