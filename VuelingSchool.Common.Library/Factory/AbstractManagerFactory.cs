using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{
    public abstract class AbstractManagerFactory
    {
        protected static AbstractManagerFactory instance;
        protected FileManager FileManager;
        public abstract FileManager CreateFileManager(string fileType);
    }
}
