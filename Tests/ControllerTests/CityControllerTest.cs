using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Helpings;
using OD_Stat.Modules.Geo.Cities;
using Tests.DemoData;

namespace Tests.ControllerTests
{
    [TestClass]
    public class CityControllerTest
    {
        private DIServiceBuilder _diServiceBuilder;
        private CityController _controller;
        private Creators _creators;

        public CityControllerTest()
        {
            _diServiceBuilder = new DIServiceBuilder();
            _controller = _diServiceBuilder.GetService<CityController>();    
            _creators = new Creators();
        }

        [TestMethod]
        public async Task  GetCity_Ok_Test()
        {
            var city = await _creators.CityCreator.CreateOne();
            var result = (await _controller.Get(city.Id)).Cast<CityViewModelGet>();
            Assert.AreEqual(city.Id, result.Id);
        }

        [TestMethod]
        public async Task Search_Ok_Test()
        {
            var cities = await _creators.CityCreator.CreateMany(10);
            var result = await _controller.Search(new CitySearchParams
            {
                Name = cities.First().Name
            });
            Assert.IsTrue(result.Items.Any());
        }

        [TestMethod]
        public async Task Add_Ok_Test()
        {
            var region = _creators.RegionCreator.CreateOne();
            var cityViewModel = new CityViewModelPost
            {
                Name = "cityName",
                RegionId = region.Id
            };
            var result = (await _controller.Add(cityViewModel)).Cast<CityViewModelGet>();
            Assert.IsTrue(result.Id != 0);
            Assert.IsTrue(result.RegionId == region.Id);
            Assert.IsTrue(result.Name == "cityName");
        }
    }
}