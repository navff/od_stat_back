using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Exceptions;
using OD_Stat.Modules.Divisions;

namespace Tests
{
    [TestClass]
    public class ExceptionsTest
    {
        [TestMethod]
        public void Test_NotFoundException()
        {
            try
            {
                throw new EntityNotFoundException<Division>(123.ToString());
            }
            catch (EntityNotFoundException<Division> e)
            {
                Assert.IsTrue(e.Message.Contains("123"));
            }
        }
    }
}