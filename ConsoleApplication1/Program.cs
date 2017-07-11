using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInConsole logInConsole = new LogInConsole();
            LogInFile logInFile = new LogInFile();
            LogInDataBase logInDataBase = new LogInDataBase();
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, false, true, true, true);
            JobLoggerRefactored log = new JobLoggerRefactored(configuration, logInDataBase, logInFile, logInConsole);
            log.LogMessage("Error", TypeLog.Error);
            log.LogMessage("Warning", TypeLog.Warning);
            log.LogMessage("Message", TypeLog.Message);
        }
    }
}
