using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.Geo.Addresses;

namespace Tests.DemoData
{
    public class AddressCreator : BaseCreator, ICreator<Address>
    {
        public AddressCreator(OdContext context) : base(context)
        {
        }


        public async Task<Address> CreateOne()
        {
            var address = NewItem();
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<IEnumerable<Address>> CreateMany(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _context.Addresses.Add(await CreateOne());
            }

            await _context.SaveChangesAsync();
            return await _context.Addresses.ToListAsync();
        }

        public static Address NewItem()
        {
            return new Address
            {
                City = "",
                Country = "Россия",
                RegionWithType = "Вологодская обл",
                Settlement = "Шайма",
                UnrestrictedValue = "162642, Вологодская обл, Череповецкий р-н, деревня Шайма",
                CityFiasId = "",
                FiasId = "774f0a4c-ce21-4fa0-a3c6-3bf53a64a182",
                RegionFiasId = "ed36085a-b2f5-454f-b9a9-1c9a678ee618",
                SettlementFiasId = "774f0a4c-ce21-4fa0-a3c6-3bf53a64a182"
            };
        }
    }
}