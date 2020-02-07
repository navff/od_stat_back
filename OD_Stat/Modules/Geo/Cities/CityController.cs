using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace OD_Stat.Modules.Geo.Cities
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;
        private IMapper _mapper;
        
        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить город по его Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Отдаёт город</response>
        /// <response code="404">Не найден город с таким Id</response>
        [HttpGet]
        [ProducesResponseType(typeof(CityViewModelGet), 200)]
        public async Task<ObjectResult> Get(int id)
        {
            City city;
            try
            {
                city = await _cityService.GetById(id);
            }
            catch (EntityNotFoundException<City>)
            {
                return this.NotFound($"There is no City with id={id}");
            }
            
            CityViewModelGet result = new CityViewModelGet
            {
                Id = city.Id,
                Name = city.Name,
                RegionId = city.RegionId,
                RegionName = city.Region.Name
            };
            return Ok(result);
        }

        /// <summary>
        /// Найти город по параметрам
        /// </summary>
        ///  <response code="200">Список городов, обёрнутый в PageView</response>
        [Route("search")]
        [HttpGet]
        [ProducesResponseType(typeof(PageView<CityViewModelGet>), 200)]
        public async Task<PageView<CityViewModelGet>> Search([FromQuery]CitySearchParams searchParams)
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

        /// <summary>
        /// Добавить город
        /// </summary>
        ///  <response code="200">Только что доабленный город</response>
        [HttpPost]
        [ProducesResponseType(typeof(CityViewModelGet), 200)]
        public async Task<ObjectResult> Add(CityViewModelPost viewModel)
        {
            var city = _mapper.Map<City>(viewModel);
            await _cityService.Add(city);
            return await Get(city.Id);
        }

        /// <summary>
        /// Изменить город
        /// </summary>
        /// <response code="200">Список городов, обёрнутый в PageView</response>
        /// <response code="404">Не найден город с таким Id</response>
        [HttpPut]
        [ProducesResponseType(typeof(CityViewModelGet), 200)]
        [Route("{id}")]
        public async Task<ObjectResult> Update([FromRoute]int id, 
                                               [FromBody]CityViewModelPost viewModel)
        {
            City result;
            try
            {
                result = await _cityService.Update(new City
                {
                    Id = id,
                    Name = viewModel.Name,
                    RegionId = viewModel.RegionId
                });
            }
            catch (EntityNotFoundException<City>)
            {
                return NotFound($"There is no City with ID = {id}");
            }
            return await Get(result.Id);
        }
    }
}