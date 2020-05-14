using System;
using System.ComponentModel.Design;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using Tests.SimpleTestClasses;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    public class DI_Container_Test : BaseTest
    {
        [Fact]
        public void TestServiceBuilder()
        {
            var testService = DiServiceBuilder.GetService<TestService>();
            var result = testService.Invoke();
            Assert.IsTrue(result == "This is string");
        }
        
        [Fact]
        public void TestAutoMapperDi()
        {
            var mapper = DiServiceBuilder.GetService<IMapper>();
            var result = mapper.Map<string>("Жопа");
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        
    }
}