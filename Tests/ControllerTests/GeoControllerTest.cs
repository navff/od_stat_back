using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Modules.Geo;

namespace Tests.ControllerTests
{
    [TestClass]
    public class GeoControllerTest
    {
        DIServiceBuilder _diServiceBuilder = new DIServiceBuilder();
        
        [TestMethod]
        public void GetCountry_Ok_Test()
        {
            var controller = _diServiceBuilder.GetService<GeoController>();
            var result = controller.GetCountry();
            Assert.AreEqual(result.Id, 123);
        }
    }
}