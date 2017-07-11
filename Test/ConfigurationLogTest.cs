using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resolution;
using Moq;
namespace Test
{
    [TestClass]
    public class ConfigurationLogTest
    {
        

  

        [TestMethod]
        public void InvalidTarget()
        {
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(false, false, false, true, false, false);
            Assert.AreEqual(false,configuration.IsLogTargetValid());
        }

        [TestMethod]
        public void ValidTarget()
        {
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, false, false, true, false, false);
            Assert.AreEqual(true, configuration.IsLogTargetValid());
        }

        [TestMethod]
        public void InvalidTypeOfMessage()
        {
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, false, false, false, false, false);
            Assert.AreEqual(false, configuration.IsTypeOfMessageValid());
        }

        [TestMethod]
        public void ValidTypeOfMessage()
        {
            ConfigurationLogEntity configuration = new ConfigurationLogEntity(true, false, false, true, false, false);
            Assert.AreEqual(true, configuration.IsTypeOfMessageValid());
        }

    }
}
