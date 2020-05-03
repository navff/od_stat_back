using AutoMapper;
using DaData.Models.Suggestions.Data;
using DaData.Models.Suggestions.Results;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.Divisions;
using OD_Stat.Modules.Geo.Addresses;

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
            
            // From third-part services
            CreateMap<AddressResult, Address>().IncludeMembers(src => src.Data);
            CreateMap<AddressData, Address>(MemberList.None);

        }
    }
}