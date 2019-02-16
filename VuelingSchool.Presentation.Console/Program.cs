using System;
using System.Collections.Generic;
using System.IO;
using VuelingSchool.Common.Library.Factory;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.Console
{
    public static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static StudentRepository sr;

        public static void Main(string[] args)
        {
            SelectTypeFile();
            SelectOption();
        }

        private static void SelectTypeFile()
        {
            string caseSwitch = null;
            System.Console.WriteLine("\n\nSelect the type of file you want to use:");
            System.Console.WriteLine("\t 1. TXT");
            System.Console.WriteLine("\t 2. XML");
            System.Console.WriteLine("\t 3. JSON");
            caseSwitch = System.Console.ReadLine();
            System.Console.WriteLine("You entered '{0}'", caseSwitch);

            string fileType = "";
            switch (caseSwitch)
            {
                case "1":
                    fileType = "txt";
                    break;
                case "2":
                    fileType = "xml";
                    break;
                default:
                    fileType = "json";
                    break;
            }

            sr = new StudentRepository( FileManagerFactory.Instance.CreateFileManager(fileType) );
        }

        public static void SelectOption()
        {
            string caseSwitch = null;
            do
            {
                System.Console.WriteLine("\n\nChoose an option:");
                System.Console.WriteLine("\t 1. Add");
                System.Console.WriteLine("\t 2. Show all");
                System.Console.WriteLine("\t 3. Get by id");
                System.Console.WriteLine("\t 4. Update by id");
                System.Console.WriteLine("\t 5. Delete by id");
                System.Console.WriteLine("\t 0. Back");
                System.Console.WriteLine("\t X. Exit");
                caseSwitch = System.Console.ReadLine();
                System.Console.WriteLine("You entered '{0}'", caseSwitch);
                
                switch (caseSwitch)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        GetAllStudents();
                        break;
                    case "3":
                        GetStudent();
                        break;
                    case "4":
                        UpdateStudent();
                        break;
                    case "5":
                        DeleteStudent();
                        break;
                    case "0":
                        SelectTypeFile();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        private static void AddStudent()
        {
            try
            {
                InputStudentParams(out string studentId, out string name, out string surname, out string birthday);
                Student student = new Student(studentId, name, surname, birthday);
                sr.AddNewStudent(student);
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
        }
        private static void GetAllStudents()
        {
            try { 
                StudentListToString(sr.GetAllStudents());
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
        }
        private static void GetStudent()
        {
            string studentId;
            System.Console.Write("\t Enter Student Id: ");
            studentId = System.Console.ReadLine();
            try
            {
                Student student = sr.GetStudentById(studentId);
                if (student == null)
                    System.Console.WriteLine("There's not any Student with such StudentId");
                else
                    System.Console.WriteLine(student.ToString());
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                System.Console.WriteLine(e.Message);
                System.Console.Read();
            }
        }
        private static void DeleteStudent()
        {
            try
            {
                System.Console.Write("\tType the StudentId: ");
                string studentId = System.Console.ReadLine();
                if (!sr.DeleteStudent(studentId))
                    System.Console.WriteLine("There's not any Student with such StudentId");
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
        }
        private static void UpdateStudent()
        {
            try
            {
                InputStudentParams(out string studentId, out string name, out string surname, out string birthday);
                sr.UpdateStudent(studentId, name, surname, birthday);
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
        }

        private static void InputStudentParams(out string StudentId, out string Name, out string Surname, out string Birthday)
        {
            System.Console.Write("\tType the StudentId: ");
            StudentId = System.Console.ReadLine();
            System.Console.Write("\tType the name: ");
            Name = System.Console.ReadLine();
            System.Console.Write("\tType the surname: ");
            Surname = System.Console.ReadLine();
            System.Console.Write("\tType the birth date (dd/mm/yyyy): ");
            Birthday = System.Console.ReadLine();
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
