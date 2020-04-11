using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Divisions
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class DivisionsController: ControllerBase, 
        ICrudController<DivisionViewModelPost, DivisionSearchParams>
    {
        private DivisionService _divisionService;
        private IMapper _mapper;

        public DivisionsController(DivisionService divisionService, IMapper mapper) 
        {
            _divisionService = divisionService;
            _mapper = mapper;
        }


        public Task<ObjectResult> Get(int id)
        {
            throw new System.NotImplementedException();
        }

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
    }
}