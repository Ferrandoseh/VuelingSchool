using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{
    public class FileManagerFactory : AbstractManagerFactory
    {
        private FileManagerFactory()
        {
        }

        public static FileManagerFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new FileManagerFactory();
                return (FileManagerFactory)instance;
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
