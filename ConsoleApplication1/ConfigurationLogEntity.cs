using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    public class ConfigurationLogEntity
    {
        public ConfigurationLogEntity(bool logToFile,bool logToConsole, bool logToDataBase,
                                      bool logWarning,bool logError,bool logMessage)
        {
            LogToFile = logToFile;
            LogToConsole = logToConsole;
            LogToDataBase = logToDataBase;
            LogWarning = logWarning;
            LogMessage = logMessage;
            LogError = logError;
        }
        //TODO: private sset
        public bool LogToFile { get; private set; }
        public bool LogToConsole { get; set; }
        public bool LogToDataBase { get; set; }
        public bool LogMessage { get; set; }
        public bool LogWarning { get; set; }
        public bool LogError { get; set; }

        public bool IsLogTargetValid()
        {
            return this.LogToFile || this.LogToDataBase || this.LogToConsole;
        }

        public bool IsTypeOfMessageValid()
        {
            return this.LogMessage || this.LogError || this.LogWarning;
        }
    }
}
