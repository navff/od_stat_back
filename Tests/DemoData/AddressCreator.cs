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
                City = "city_name",
                Country = "country_name",
                Region = "region_name",
                Settlement = "settlement_name",
                UnrestrictedValue = "urestricted_value",
                CityFiasId = "city_fias_id",
                FiasId = "fias_id",
                RegionFiasId = "region_fias_id",
                SettlementFiasId = "settlement_fias_id"
            };
        }
    }
}