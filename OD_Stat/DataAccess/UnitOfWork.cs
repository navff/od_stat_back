using OD_Stat.Modules.Geo;

namespace OD_Stat.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public OdContext Context { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public IRegionRepository RegionRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        
        
        public UnitOfWork(OdContext context)
        {
            Context = context;
            CountryRepository = new CountryRepository(context);
            RegionRepository = new RegionRepository(context);
            CityRepository = new CityRepository(context);
        }

        
        
        public UnitOfWork(ICountryRepository countryRepository, 
                          IRegionRepository regionRepository,
                          ICityRepository cityRepository)
        {
            CountryRepository = countryRepository;
            RegionRepository = regionRepository;
            CityRepository = cityRepository;
        }

    }
}