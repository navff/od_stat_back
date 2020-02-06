using OD_Stat.Modules.Geo.Cities;
using OD_Stat.Modules.Geo.Countries;
using OD_Stat.Modules.Geo.Regions;

namespace OD_Stat.DataAccess
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get; set; }
        IRegionRepository RegionRepository { get; set; }
        ICityRepository CityRepository { get; set; }
    }
}