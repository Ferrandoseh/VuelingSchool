using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;
using System.IO;

namespace VuelingSchool.Common.Library.Utils
{
    /// <summary>
    /// Provides the methods to perform the CRUD operations into a file.
    /// </summary>
    public abstract class FileManager
    {
        protected static readonly string repositoryPath = ConfigurationManager.AppSettings.Get("localPath");
        protected static readonly string environmentPath = Environment.GetEnvironmentVariable("localPath",
            EnvironmentVariableTarget.User);
        protected string localPath;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The class constructor.
        /// Computes the path where the file to work on will be stored and creates the file 
        /// where all the operations will be performed.
        /// </summary>
        public FileManager()
        {
            ComputeFilePath();
            if (!File.Exists(localPath))
                CreateFile();
        }

        /// <summary>
        /// Adds a new object into the file.
        /// </summary>
        /// <returns>
        /// Return the student is just written reading it after the insertion.
        /// </returns>
        /// <param name="o"> The object we want to format and add into the file.</param>
        public abstract Student Add(Student o);
        /// <summary>
        /// Gets the content of the file.
        /// </summary>
        /// <returns>
        /// Returns a List<Student> if there are elements into the file, otherwise it
        /// returns null
        /// </returns>
        /// /// <seealso cref="System.String">
        /// Reads the file moving all its objects into a List that will be 
        /// returned once its filled up with the file information.
        /// </seealso>
        public abstract List<Student> GetAll();
        /// <summary>
        /// Gets the last element of the file.
        /// </summary>
        /// <returns>
        /// Returns the last object found.
        /// If there is none then returns null.
        /// </returns>
        /// /// <seealso cref="System.String">
        /// Reads the file returning just its last object.
        /// </seealso>
        public abstract Student GetLast();
        /// <summary>
        /// Gets the element of the file that matches the entry parameter.
        /// </summary>
        /// <param name="id"> The id we want the object found has as an attribute.</param>
        /// <returns>
        /// Returns the last object found.
        /// If there is none then returns null.
        /// </returns>
        /// /// <seealso cref="System.String">
        /// Reads the file returning just the object with the entry parameter as its id.
        /// </seealso>
        public abstract Student GetObjectById(string id);
        /// <summary>
        /// Deletes an object from the file
        /// </summary>
        /// <param name="id">The id to identify the object to be deleted.</param>
        /// <returns>
        /// Returns true if the object to be deleted was found.
        /// Otherwise returns false.
        /// </returns>
        public abstract bool DeleteObject(string id);
        /// <summary>
        /// Updates an element from the file.
        /// </summary>
        /// <param name="o">The object which contains the id to identify the object to be 
        /// updated and the params to be modified.</param>
        /// <returns>
        /// Returns true if the object to be updated was found.
        /// Otherwise returns false.
        /// </returns>
        /// /// <seealso cref="System.String">
        /// The object will be updated if theres an object with the same id as the input
        /// object.
        /// The other parameters of the input object will be the next params for the object
        /// To be modified.
        /// </seealso>
        public abstract Student UpdateObject(Student o);        
        /// <summary>
        /// Creates the path that belongs to the file to work on.
        /// </summary>
        /// /// <seealso cref="System.String">
        /// To compute the file path it will get it from the environment variables in the
        /// system, if found. Otherwise it will use a repository variable contained in
        /// the app.config file.
        /// </seealso>
        public abstract void ComputeFilePath();
        /// <summary>
        /// Creates the file to work on.
        /// </summary>
        /// /// <seealso cref="System.String">
        /// It creates the file where the FileManager will work on.
        /// </seealso>
        public abstract void CreateFile();
    }
}
