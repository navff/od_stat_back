using System.Linq;
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
        public async Task Should_return_some_addresses_by_word()
        {
            var result = await _daDataService.GetAddressSuggestions("Шайма Вологодская 11");
            result.Should().HaveCount(c => c > 0);
        }
        
        [Fact]
        public async Task Should_find_address_by_FiasId()
        {
            var fiasId = "62f7b576-0ee7-4139-9ebd-7cc9dd70602b";
            var result = await _daDataService.GetAddressByFiasId(fiasId);
            result.Settlement.Should().Contain("Шайма");
        }
    }
}