using System.Threading.Tasks;
using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Cities
{
    public interface ICityRepository : ICrudOperations<City>
    {
        Task<PageView<City>> Search(CitySearchParams searchParams);
    }

    
}