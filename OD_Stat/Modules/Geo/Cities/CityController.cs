using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
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
        public async Task<CityViewModelGet> Get(int id)
        {
            var city = await _cityService.GetById(id);
            CityViewModelGet result = new CityViewModelGet
            {
                Id = city.Id,
                Name = city.Name,
                RegionId = city.RegionId,
                RegionName = city.Region.Name
            };
            return result;
        }

        [Route("search")]
        [HttpGet]
        public async Task<PageView<CityViewModelGet>> Search(CitySearchParams searchParams)
        {
            var cities = await _cityService.Search(searchParams);
            return new PageView<CityViewModelGet>
            {
                CurrentPage = searchParams.Page,
                Items = cities.Items.Select( c => new CityViewModelGet
                {
                    Id = c.Id,
                    Name = c.Name,
                    RegionId = c.RegionId,
                    RegionName = c.Region.Name
                })
            };
        }

        [HttpPost]
        public async Task<CityViewModelGet> Add(CityViewModelPost viewModel)
        {
            var city = _mapper.Map<City>(viewModel);
            await _cityService.Add(city);
            return await Get(city.Id);
        }
    }
}