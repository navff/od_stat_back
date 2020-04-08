using System.Collections.Generic;
using System.Threading.Tasks;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Divisions
{
    public class DivisionService: BaseCrudService<Division, DivisionShort, DivisionSearchParams>
    {
        public DivisionService(OdContext context) : base(context)
        {
        }

        public override async Task<Division> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<Division> Create(Division entity)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<Division> Update(Division entity)
        {
            throw new System.NotImplementedException();
        }

        public override async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IEnumerable<DivisionShort>> Search(DivisionSearchParams searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}