using AutoMapper;
using OD_Stat.Modules.Geo;

namespace OD_Stat.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        public ICountryRepository CountryRepository { get; set; }
        public IRegionRepository RegionRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        
        
        public UnitOfWork(OdContext context, IMapper mapper)
        {
            _mapper = mapper;
            CountryRepository = new CountryRepository(context, _mapper);
            RegionRepository = new RegionRepository(context, _mapper);
            CityRepository = new CityRepository(context);
        }
    }
}