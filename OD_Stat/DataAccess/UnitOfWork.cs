using AutoMapper;
using OD_Stat.Modules.Geo;

namespace OD_Stat.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        public OdContext Context { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public IRegionRepository RegionRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        
        
        public UnitOfWork(OdContext context, IMapper mapper)
        {
            _mapper = mapper;
            Context = context;
            CountryRepository = new CountryRepository(context, _mapper);
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