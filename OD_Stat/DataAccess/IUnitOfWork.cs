using OD_Stat.Modules.Geo;

namespace OD_Stat.DataAccess
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get; set; }
        IRegionRepository RegionRepository { get; set; }
        ICityRepository CityRepository { get; set; }
    }
}