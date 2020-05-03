using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Modules.DaData;

namespace Tests.ServicesTests
{
    [TestClass]
    public class DaDataService_Test : BaseTest
    {
        private DaDataService _daDataService;

        public DaDataService_Test()
        {
            _daDataService = DiServiceBuilder.GetService<DaDataService>();
        }

        [TestMethod]
        public async Task GetData_Test()
        {
            var result = await _daDataService.GetAddressSuggestions("Шайма Вологодская 11");
            Assert.IsTrue(result.Count > 0);
        }
    }
}