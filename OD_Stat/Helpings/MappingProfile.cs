using AutoMapper;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Cities;
using OD_Stat.Modules.Geo.Countries;

namespace OD_Stat.Helpings
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            // entities
            CreateMap<Country, Country>();
            
            // ViewModel to Entities
            CreateMap<CityViewModelGet, City>();
            CreateMap<CityViewModelPost, City>();


            // Entities to viewModels
            CreateMap<City, CityViewModelGet>();
        }
    }
}