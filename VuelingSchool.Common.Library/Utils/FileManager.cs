using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
    public abstract class FileManager
    {
        protected static readonly string repositoryPath = ConfigurationManager.AppSettings.Get("localPath");
        protected static readonly string environmentPath = Environment.GetEnvironmentVariable("localPath",
            EnvironmentVariableTarget.User);
        protected string localPath;

        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected FileManager() => ComputeFilePath();
        public abstract void ComputeFilePath();

        public abstract Student Add(Student o);
        public abstract List<Student> GetAll();
        public abstract Student GetLast();
        public abstract Student GetObjectById(string id);
        public abstract bool DeleteObject(string id);
        public abstract Student UpdateObject(Student o);
    }
}
