using System;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Helpings;
using OD_Stat.Modules.Divisions;
using Tests.DemoData;

namespace Tests.ControllerTests
{
    [TestClass]
    public class CityControllerTest
    {
        private readonly DivisionsController _controller;
        private readonly Creators _creators;

        public CityControllerTest()
        {
            var diServiceBuilder = new DIServiceBuilder();
            _controller = diServiceBuilder.GetService<DivisionsController>();    
            _creators = new Creators();
        }

        [TestMethod]
        public async Task  GetCity_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var result = (await _controller.Get(division.Id)).Cast<DivisionViewModelGet>();
            Assert.AreEqual(division.Id, result.Id);
        }

        [TestMethod]
        public async Task Search_Ok_Test()
        {
            var divisions = await _creators.DivisionCreator.CreateMany(10);
            var result = await _controller.Search(new DivisionSearchParams()
            {
                Word = divisions.First().Name
            });
            Assert.IsTrue( result.Cast<PageView<DivisionViewModelList>>()
                            .Items.Any());
        }

        [TestMethod]
        public async Task Add_Ok_Test()
        {
            var cityViewModel = new DivisionViewModelPost()
            {
                Name = "divisonName",
                FiasId = "fias_id"
            };
            var result = (await _controller.Post(cityViewModel))
                .Cast<DivisionViewModelGet>();
            Assert.IsTrue(result.Id != 0);
            Assert.IsTrue(result.Name == "divisonName");
        }

        [TestMethod]
        public async Task Update_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var rndString = Guid.NewGuid().ToString();
            var divisionViewModel = new DivisionViewModelPost()
            {
                Name = rndString,
            };
            var result = (await _controller.Put(division.Id, divisionViewModel))
                .Cast<DivisionViewModelGet>();
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual(rndString, result.Name);
            Assert.IsTrue(result.AddressId != 0);
        }

        [TestMethod]
        public async Task Delete_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var result = (await _controller.Delete(division.Id)).Cast<string>();
            Assert.AreEqual("Deleted", result);
        }
    }
}