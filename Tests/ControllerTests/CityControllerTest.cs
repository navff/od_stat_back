using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Modules.Geo.Cities;
using Tests.DemoData;

namespace Tests.ControllerTests
{
    [TestClass]
    public class CityControllerTest
    {
        DIServiceBuilder _diServiceBuilder = new DIServiceBuilder();
        
        [TestMethod]
        public async Task  GetCity_Ok_Test()
        {
            var controller = _diServiceBuilder.GetService<CityController>();
            var creators = new Creators();
            var city = await creators.CityCreator.CreateOne();
            var result = await controller.Get(city.Id);
            Assert.AreEqual(city.Id, result.Id);
        }
    }
}