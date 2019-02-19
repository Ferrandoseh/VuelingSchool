using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{   
    /// <summary>  
    ///  This class generates factories, following the Abstract Factory Pattern
    /// </summary>
    public abstract class AbstractManagerFactory
    {
        protected static FileManagerFactory managerFactory;

        protected static readonly log4net.ILog Log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Creates FileManager Factory
        /// </summary>
        /// <param name="fileType">The extension of the files to be treated.</param>
        /// <returns>
        /// Returns the instance of the FileManager acording to the fileType to manage.
        /// </returns>
        public abstract FileManager CreateFileManager(string fileType);
    }
}
