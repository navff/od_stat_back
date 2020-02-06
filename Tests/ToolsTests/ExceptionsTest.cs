using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Exceptions;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Cities;

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
                throw new EntityNotFoundException<City>(123.ToString());
            }
            catch (EntityNotFoundException<City> e)
            {
                Assert.IsTrue(e.Message.Contains("123"));
            }
        }
    }
}