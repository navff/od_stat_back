using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests
{
    [TestClass]
    public class DI_Container_Test : BaseTest
    {
        [TestMethod]
        public void TestServiceBuilder()
        {
            var testService = _serviceBuilder.GetService<TestService>();
            var result = testService.Invoke();
            Assert.IsTrue(result == "This is string");
        }

        
    }
}