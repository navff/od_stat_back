using System.Threading.Tasks;
using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Countries
{
    public interface ICountryRepository : ICrudOperations<Countries.Country>
    {
        Task<PageView<Countries.Country>> Search(CountrySearchParams searchParams);
    }
}