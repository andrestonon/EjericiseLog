using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    public class LogInFile : ILogIn
    {

        public void LogMessage(string message, TypeLog type)
        {
                string path = SetPath();
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(String.Format("{0}{1}", type, message));
                    }
                }
                finally
                {
                    if (fs != null)
                        fs.Dispose();
                }
        }

        private string SetPath()
        {
            string path = GetPath();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string pathFile = GetPathFile();
            if (!File.Exists(pathFile))
                File.Create(pathFile).Close();
            return pathFile;
        }

        private string GetPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"].ToString();
        }

        private string GetPathFile()
        {
            return GetPath() + "LogFile" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";
        }

    }
}
