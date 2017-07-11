using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Resolution
{
    public class JobLoggerRefactored : IJobLoggerRefactored 
    {
        private readonly ILogIn LoggerInDataBase;
        private readonly ILogIn LoggerInFile;
        private readonly ILogIn LoggerInConsole;
        private ConfigurationLogEntity ConfigurationLogEntity;

        public JobLoggerRefactored(ConfigurationLogEntity configurationEntity,
                                   ILogIn loggerInDataBase,
                                   ILogIn loggerInFile,
                                   ILogIn loggerInConsole)
        {
            Inicialice(configurationEntity);
            LoggerInConsole = loggerInConsole;
            LoggerInDataBase = loggerInDataBase;
            LoggerInFile = loggerInFile;
        }

        private void Inicialice(ConfigurationLogEntity configurationEntity)
        {
            if (configurationEntity == null)
                throw new ArgumentNullException(nameof(configurationEntity));
            ConfigurationLogEntity = configurationEntity;
            if (!ConfigurationLogEntity.IsLogTargetValid())
                throw new Exception("Invalid configuration");
            if (!ConfigurationLogEntity.IsTypeOfMessageValid())
                throw new Exception("Error or Warning or Message must be specified");
        }

        public void LogMessage(string message, TypeLog type)
        {
            if (!this.IsMessageValid(message))
                return;

            if(CompareConfigurationWithType(type))
            {
                if(ConfigurationLogEntity.LogToDataBase)
                    LoggerInDataBase.LogMessage(message, type);
                if (ConfigurationLogEntity.LogToFile)
                    LoggerInFile.LogMessage(message, type);
                if (ConfigurationLogEntity.LogToConsole)
                    LoggerInConsole.LogMessage(message, type);
            }

        }

        private bool IsMessageValid(string message)
        {
            return !String.IsNullOrWhiteSpace(message);
        }

        public bool CompareConfigurationWithType(TypeLog type)
        {
            if (((type == TypeLog.Error) && ConfigurationLogEntity.LogError)
                   || ((type == TypeLog.Message) && ConfigurationLogEntity.LogMessage)
                   || ((type == TypeLog.Warning) && ConfigurationLogEntity.LogWarning))
                return true;
            else
                return false;
        }





    }
}