using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Modules.Geo;

namespace Tests.ControllerTests
{
    [TestClass]
    public class GeoControllerTest
    {
        ServiceBuilder _serviceBuilder = new ServiceBuilder();
        
        [TestMethod]
        public void GetCountry_Ok_Test()
        {
            var controller = _serviceBuilder.GetService<GeoController>();
            var result = controller.GetCountry();
            Assert.AreEqual(result.Id, 123);
        }
    }
}