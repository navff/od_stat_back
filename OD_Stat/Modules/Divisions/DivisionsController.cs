using System;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.CommonModulesHelpings;
using OD_Stat.Modules.Geo.Addresses;

namespace OD_Stat.Modules.Divisions
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class DivisionsController: ControllerBase
    {
        private readonly DivisionService _divisionService;
        private readonly AddressService _addressService;
        private readonly IMapper _mapper;

        public DivisionsController(
            DivisionService divisionService, 
            IMapper mapper, 
            AddressService addressService) 
        {
            _divisionService = divisionService;
            _mapper = mapper;
            _addressService = addressService;
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
        public async Task<IActionResult> Put(int divisionId, DivisionViewModelPost viewModel)
        {
            var division = _mapper.Map<Division>(viewModel);
            var address = _addressService.GetByFiasId(viewModel.FiasId);
            division.AddressId = address.Id;
            division.Id = divisionId;
            
            try
            {
                var updatedDivision = await _divisionService.Update(division);
                var result = _mapper.Map<DivisionViewModelGet>(updatedDivision);
                return Ok(result);
            }
            catch (EntityNotFoundException<Division> e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _divisionService.Delete(id);
                return Ok("Deleted");
            }
            catch (EntityNotFoundException<Division> e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpGet]
        [Authorize]
        public async Task<ObjectResult> Search(DivisionBaseSearchParams baseSearchParams)
        {
            var divisions = await _divisionService.Search(baseSearchParams);
            var result = _mapper.Map<PageView<DivisionViewModelList>>(divisions);
            return Ok(result);
        }
    }
}