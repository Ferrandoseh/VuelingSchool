using System.Collections.Generic;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.DataAccess.Repository
{
    /// <summary>
    /// Provides the methods to perform the CRUD operations for the Student class
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// The class constructor.
        /// </summary>
        FileManager FileManager { get; set; }

        /// <summary>
        /// Adds a new object into the file.
        /// </summary>
        /// <param name="student">The object we want to format and add into the file.</param>
        /// <returns>
        /// Returns the student is just written reading it after the insertion.
        /// </returns>
        /// <exception cref = "System.UnauthorizedAccessException"></exception>
        /// <exception cref = "System.ArgumentNullException"></exception>
        /// <exception cref = "System.ArgumentException"></exception>
        /// <exception cref = "System.PathTooLongException"> </exception>
        /// <exception cref = "System.DirectoryNotFoundException"></exception>
        /// <exception cref = "System.NotSupportedException"></exception>
        /// <exception cref = "System.IOException"></exception>
        /// <exception cref = "System.SecurityException" ></exception>
        Student AddNewStudent(Student student);
        /// <summary>
        /// Gets all the students stored.
        /// </summary>
        /// <returns>
        /// Returns a List<Student> if there are elements into the file, otherwise it
        /// returns null
        /// </returns>
        /// <exception cref = "System.UnauthorizedAccessException"></exception>
        /// <exception cref = "System.ArgumentNullException"></exception>
        /// <exception cref = "System.ArgumentException"></exception>
        /// <exception cref = "System.PathTooLongException"> </exception>
        /// <exception cref = "System.DirectoryNotFoundException"></exception>
        /// <exception cref = "System.NotSupportedException"></exception>
        /// <exception cref = "System.IOException"></exception>
        /// <exception cref = "System.SecurityException" ></exception>
        List<Student> GetAllStudents();
        /// <summary>
        /// Gets the student stored that matches the entry parameter.
        /// </summary>
        /// <param name="id"> The id we want the object found has as an attribute.</param>
        /// <returns>
        /// Returns the object found.
        /// If there is none then returns null.
        /// </returns>
        /// /// <seealso cref="System.String">
        /// Reads the file returning just the object with the entry parameter as its id.
        /// </seealso>
        /// <param name="o"> The object we want to format and add into the file.</param>
        /// <exception cref = "System.UnauthorizedAccessException"></exception>
        /// <exception cref = "System.ArgumentNullException"></exception>
        /// <exception cref = "System.ArgumentException"></exception>
        /// <exception cref = "System.PathTooLongException"> </exception>
        /// <exception cref = "System.DirectoryNotFoundException"></exception>
        /// <exception cref = "System.NotSupportedException"></exception>
        /// <exception cref = "System.IOException"></exception>
        /// <exception cref = "System.SecurityException" ></exception>
        Student GetStudentById(string studentId);
        /// <summary>
        /// Deletes an object from the file
        /// </summary>
        /// <param name="id">The id to identify the object to be deleted.</param>
        /// <returns>
        /// Returns true if the object to be deleted was found.
        /// Otherwise returns false.
        /// </returns>
        /// <param name="o"> The object we want to format and add into the file.</param>
        /// <exception cref = "System.UnauthorizedAccessException"></exception>
        /// <exception cref = "System.ArgumentNullException"></exception>
        /// <exception cref = "System.ArgumentException"></exception>
        /// <exception cref = "System.PathTooLongException"> </exception>
        /// <exception cref = "System.DirectoryNotFoundException"></exception>
        /// <exception cref = "System.NotSupportedException"></exception>
        /// <exception cref = "System.IOException"></exception>
        /// <exception cref = "System.SecurityException" ></exception>
        bool DeleteStudent(string studentId);
        /// <summary>
        /// Updates an element from the file.
        /// </summary>
        /// <param name="studentId">The id of the student we want to modify</param>
        /// <param name="name">The new name we want to assign to the student</param>
        /// <param name="surname">The new surname we want to assign to the student</param>
        /// <param name="birthday">The new birthday we want to assign to the student</param>
        /// <returns>
        /// Returns the object updated if it was found.
        /// Otherwise returns false.
        /// </returns>
        /// <param name="o"> The object we want to format and add into the file.</param>
        /// <exception cref = "System.UnauthorizedAccessException"></exception>
        /// <exception cref = "System.ArgumentNullException"></exception>
        /// <exception cref = "System.ArgumentException"></exception>
        /// <exception cref = "System.PathTooLongException"> </exception>
        /// <exception cref = "System.DirectoryNotFoundException"></exception>
        /// <exception cref = "System.NotSupportedException"></exception>
        /// <exception cref = "System.IOException"></exception>
        /// <exception cref = "System.SecurityException" ></exception>
        Student UpdateStudent(string studentId, string name, string surname, string birthday);
        
    }
}
