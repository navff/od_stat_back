using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests
{
    [TestClass]
    public class DI_Container_Test
    {
        [TestMethod]
        public void TestServiceBuilder()
        {
            ServiceBuilder serviceBuilder = new ServiceBuilder();
            var testService = serviceBuilder.GetService<TestService>();
            var result = testService.Invoke();
            Assert.IsTrue(result == "This is string");
        }
    }
}