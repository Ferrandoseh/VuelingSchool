using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{
    public class FileManagerFactory : AbstractManagerFactory
    {
        private FileManager FileManager;
        private FileManagerFactory()
        {
        }

        public static FileManagerFactory Instance
        {
            get
            {
                if (managerFactory == null)
                    managerFactory = new FileManagerFactory();
                return (FileManagerFactory)managerFactory;
            }
        }

        public override FileManager CreateFileManager(string fileType)
        {
            switch (fileType)
            {
                case "txt":
                    FileManager = new TxtManager();
                    break;
                case "xml":
                    FileManager = new XmlManager();
                    break;
                case "json":
                    FileManager = new JsonManager();
                    break;
            }
            return FileManager;
        }
    }
}
