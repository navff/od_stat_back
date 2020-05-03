using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Divisions
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class DivisionsController: ControllerBase
    {
        private DivisionService _divisionService;
        private IMapper _mapper;

        public DivisionsController(DivisionService divisionService, IMapper mapper) 
        {
            _divisionService = divisionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ObjectResult> Get([FromRoute]int id)
        {
            var division = await _divisionService.Get(id);
            return Ok(_mapper.Map<DivisionViewModelGet>(division));
        }

        [HttpPost]
        public async Task<ObjectResult> Post(DivisionViewModelPost viewModel)
        {
            var division = await _divisionService.Create(
                viewModel.DirectorUserId,
                viewModel.FiasId,
                viewModel.DivisionType,
                viewModel.Name,
                viewModel.ParentDivisionId);
            return await Get(division.Id);
        }
        
        [HttpPut]
        public Task<ObjectResult> Put(int divisionId, DivisionViewModelPost viewModel)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        public Task<ObjectResult> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public Task<ObjectResult> Search(DivisionSearchParams searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}