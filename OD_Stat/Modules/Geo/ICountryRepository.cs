using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    public interface ICountryRepository : ICrudRepository<Country>
    {
        Task<PageView<Country>> Search(CountrySearchParams searchParams);
    }
}