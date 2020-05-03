using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Modules.Divisions;
using Tests.DemoData;
using Tests.ToolsTests;

namespace Tests
{
    [TestClass]
    public class DivisionService_Test: BaseTest
    {
        private readonly Creators _creators;
        private readonly DivisionService _divisionService;
        public DivisionService_Test()
        {
            var diServiceBuilder = new DIServiceBuilder();
            _divisionService = diServiceBuilder.GetService<DivisionService>();    
            _creators = new Creators();
        }

        [TestMethod]
        public async Task GetById_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var result = await _divisionService.Get(division.Id);
            Assert.IsTrue(result.Id == division.Id);
            Assert.IsTrue(result.Name == division.Name);
            Assert.IsTrue(result.Address.CityFiasId == division.Address.CityFiasId);
        }
    }
}