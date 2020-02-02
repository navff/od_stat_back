using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            
        }

        [TestMethod]
        public void TestMethod1()
        {
            ConfigBuilder configBuilder = new ConfigBuilder();
            configBuilder.Run();
            Assert.IsTrue(true);
        }
    }
}