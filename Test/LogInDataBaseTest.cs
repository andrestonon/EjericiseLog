using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resolution;

namespace Test
{
    [TestClass]
    public class LogInDataBaseTest
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LogInDataBaseException()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, true, true, true, true);
            string message = "Error";
            TypeLog type = TypeLog.Error;
            //Act
            LogInDataBase logInDataBase = new LogInDataBase();
            logInDataBase.LogMessage(message, type);
        }

    }
}
