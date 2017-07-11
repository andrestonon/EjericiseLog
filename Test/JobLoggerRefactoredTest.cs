using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resolution;
using Moq;
namespace Test
{
    [TestClass]
    public class JobLoggerRefactoredTest
    {
        private Mock<ILogIn> loggerDataBase;
        private Mock<ILogIn> loggerFile;
        private Mock<ILogIn> loggerConsole;
        [TestInitialize]
        public void Init()
        {
            this.loggerConsole = new Mock<ILogIn>();
            this.loggerFile = new Mock<ILogIn>();
            this.loggerDataBase = new Mock<ILogIn>();            
        }

        [TestMethod]
        public void LogInFileWarning()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, false, false, true , false, false);
            VerifyCall(configuration, "Warning", TypeLog.Warning);
        }

        [TestMethod]
        public void LogInFileError()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, false, true, true, true);
            VerifyCall(configuration, "Error", TypeLog.Error);
        }

        [TestMethod]
        public void LogInConsoleMessage()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true , true, true, true, true);
            VerifyCall(configuration, "Message", TypeLog.Message);
        }

        [TestMethod]
        public void LogInDataBaseWarning()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, true, true, true, true);
            VerifyCall(configuration, "Warning", TypeLog.Warning);
        }

        [TestMethod]
        public void DontLogInFileNothing()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(false,true, true, true, false, true);
            VerifyDontCall(configuration, "Error", TypeLog.Error);
        }

        [TestMethod]
        public void DontLogInDataBaseNothing()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true,true,false, true, false, true);
            VerifyDontCall(configuration, "Error", TypeLog.Error);
        }

        [TestMethod]
        public void DontLogInDataConsoleNothing()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, false, false, true, false, true);
            VerifyDontCall(configuration, "Error", TypeLog.Error);
        }


        [TestMethod]
        public void DontLogInFileError()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, true,true, false,true);
            VerifyDontCall(configuration, "Error", TypeLog.Error);
        }

        [TestMethod]
        public void DontLogInFileWarning()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, true, false, false,true);
            VerifyDontCall(configuration, "Warning", TypeLog.Warning);
        }

        [TestMethod]
        public void DontLogInFileMessage()
        {
            //Arrange
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, true, true, true, false,false);
            VerifyDontCall(configuration, "Message", TypeLog.Message);
        }

        private void VerifyCall(ConfigurationLogEntity configuration, string message, TypeLog type)
        {
            //Arrange
            JobLoggerRefactored log = new JobLoggerRefactored(configuration, this.loggerDataBase.Object, this.loggerFile.Object, this.loggerConsole.Object);
            //Act
            log.LogMessage(message, type);
            //Assert
            this.loggerFile.Verify(v => v.LogMessage(message, type));
        }

        private void VerifyDontCall(ConfigurationLogEntity configuration, string message, TypeLog type)
        {
            //Arrange
            JobLoggerRefactored log = new JobLoggerRefactored(configuration, this.loggerDataBase.Object, this.loggerFile.Object, this.loggerConsole.Object);
            //Act
            log.LogMessage(message, type);
            //Assert
            this.loggerFile.Verify(v => v.LogMessage(message, type), Times.Never());
        }

    }
}
