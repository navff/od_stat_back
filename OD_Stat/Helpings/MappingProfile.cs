using AutoMapper;
using OD_Stat.Modules.Divisions;

namespace OD_Stat.Helpings
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            // entities
            CreateMap<Division, DivisionShort>();
            
            // ViewModel to Entities
            CreateMap<DivisionViewModelPost, Division>();
            CreateMap<DivisionViewModelGet, Division>();


            // Entities to viewModels
            CreateMap<Division, DivisionViewModelGet>();
            CreateMap<Division, DivisionViewModelList>();
        }
    }
}