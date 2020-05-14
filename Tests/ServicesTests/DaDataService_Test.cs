using System.Threading.Tasks;
using FluentAssertions;
using OD_Stat.Modules.DaData;
using Xunit;

namespace Tests.ServicesTests
{
    public class DaDataService_Test : BaseTest
    {
        private DaDataService _daDataService;

        public DaDataService_Test()
        {
            _daDataService = DiServiceBuilder.GetService<DaDataService>();
        }

        [Fact]
        public async Task GetData_Test()
        {
            var result = await _daDataService.GetAddressSuggestions("Шайма Вологодская 11");
            result.Should().HaveCount(c => c > 0);
        }
    }
}