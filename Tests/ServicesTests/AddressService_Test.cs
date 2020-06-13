using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DaData.Models.Additional.Requests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.DaData;
using Tests.Scenarios;
using Xunit;

namespace Tests.ServicesTests
{
    public class AddressService_Test : BaseTest
    {
        private AddressService _addressService;
        protected OdContext _context;

        public AddressService_Test()
        {
            _addressService = DiServiceBuilder.GetService<AddressService>();;
            _context = DiServiceBuilder.GetService<OdContext>();;
        }

        [Fact]
        public async Task Should_return_some_addresses_by_FiasId()
        {
            var fiasId = "62f7b576-0ee7-4139-9ebd-7cc9dd70602b";
            var address = CreateAddress();
            var result = await _addressService.GetByFiasId(fiasId);
            result.FiasId.Should().Be(fiasId);    
        }

        // ARRANGE
        private Address CreateAddress()
        {
            var address = new Address
            {
                City = "Жопа мира",
                Country = "Пуп мира",
                RegionWithType = "Замечательная область",
                FiasId = "62f7b576-0ee7-4139-9ebd-7cc9dd70602b",
                Settlement = "Деревня в Жопе мира",
                UnrestrictedValue = "Анрестриктед валуе",
                RegionFiasId = "Регион фиас айди",
                SettlementFiasId = "Сеттлмент фиас айди",
                CityFiasId = "Сити фиас айди"
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }
    }
}
