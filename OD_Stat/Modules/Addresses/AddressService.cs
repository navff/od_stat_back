using System.Threading.Tasks;
using Common;
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

        public override Task<Address> Create(Address entity)
        {
            throw new System.NotImplementedException();
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