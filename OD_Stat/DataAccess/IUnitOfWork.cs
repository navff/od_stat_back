using OD_Stat.Modules.Geo;

namespace OD_Stat.DataAccess
{
    public interface IUnitOfWork
    {
        OdContext Context { get; set; }
        ICountryRepository CountryRepository { get; set; }
        IRegionRepository RegionRepository { get; set; }
        ICityRepository CityRepository { get; set; }
    }
}