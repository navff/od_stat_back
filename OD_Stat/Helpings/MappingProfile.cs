using AutoMapper;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Countries;

namespace OD_Stat.Helpings
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Country, Country>();
            
        }
    }
}