using System.Threading.Tasks;
using Common;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    class CityRepository : AbstractRepo, ICityRepository
    {
        private OdContext _context { get; set; }
        
        public CityRepository(OdContext context) : base(context)
        { 
            this._context = context;
        }
        
        public  Task<City> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<City> Add(City country)
        {
            throw new System.NotImplementedException(); 
        }

        public Task<City> Update(City country)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PageView<City>> Search(string? code = null, string? name = null, int? page=1, int? take=100)
        {
            throw new System.NotImplementedException();
        }

    }
}