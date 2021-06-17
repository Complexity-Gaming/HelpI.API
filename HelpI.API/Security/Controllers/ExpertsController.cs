using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Services;
using HelpI.API.SeedWork.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Security.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ExpertsController : ControllerBase
    {
        private readonly IExpertService _expertService;
        private readonly IMapper _mapper;

        public ExpertsController(IExpertService expertService, IMapper mapper)
        {
            _expertService = expertService;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpertResource>), 200)]
        public async Task<IEnumerable<ExpertResource>> GetAllAsync()
        {
            var experts = await _expertService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Expert>, IEnumerable<ExpertResource>>(experts);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExpertResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _expertService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);
            return Ok(expertResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveExpertResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var expert = _mapper.Map<SaveExpertResource, Expert>(resource);
            var result = await _expertService.UpdateAsync(id, expert);

            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);

            return Ok(expertResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _expertService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);
            return Ok(expertResource);
        }
    }
}
