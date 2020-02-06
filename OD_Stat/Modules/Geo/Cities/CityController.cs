using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OD_Stat.Modules.Geo.Countries;

namespace OD_Stat.Modules.Geo.Cities
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;
        private IMapper _mapper;
        
        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<CityViewModel> Get(int id)
        {
            var city = await _cityService.GetById(id);
            CityViewModel result = new CityViewModel
            {
                Id = city.Id,
                Name = city.Name,
                RegionId = city.RegionId,
                RegionName = city.Region.Name
            };
            return result;
        }
    }
}