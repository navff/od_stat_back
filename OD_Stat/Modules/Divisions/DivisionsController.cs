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
            return Ok("nothing");
        }
/*
        public Task<ObjectResult> Post(DivisionViewModelPost viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ObjectResult> Put(int divisionId, DivisionViewModelPost viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ObjectResult> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ObjectResult> Search(DivisionSearchParams searchParams)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}