using System.Threading.Tasks;
using Common;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    class RegionRepository : AbstractRepo, IRegionRepository
    {
        private OdContext _context;
        public RegionRepository(OdContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Region> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Region> Add(Region country)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Region> Update(Region country)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PageView<Region>> Search(string? code = null, string? name = null, 
                                                   int? page=1, int? take=100)
        {
            throw new System.NotImplementedException();
        }

        
    }
}