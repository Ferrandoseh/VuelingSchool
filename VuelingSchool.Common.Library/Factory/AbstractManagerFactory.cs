using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{
    public abstract class AbstractManagerFactory
    {
        protected static AbstractManagerFactory managerFactory;
        public abstract FileManager CreateFileManager(string fileType);
    }
}
