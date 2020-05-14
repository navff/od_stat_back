using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;
using OD_Stat.Modules.Geo.Addresses;

namespace OD_Stat.Modules.Addresses
{
    public class AddressService: BaseCrudService<Address, Address, AddressSearchParams>
    {
        public AddressService(OdContext context) : base(context)
        {
        }

        public override Task<Address> Get(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<Address> GetByFiasId(string fiasId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.FiasId == fiasId);
        }

        public override async Task<Address> Create(Address entity)
        {
            var existingAddress = await GetByFiasId(entity.FiasId);
            if (existingAddress == null)
            {
                await _context.Addresses.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                entity = existingAddress;
            }
            return entity;
        }

        public override Task<Address> Update(Address entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<PageView<Address>> Search(AddressSearchParams searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}