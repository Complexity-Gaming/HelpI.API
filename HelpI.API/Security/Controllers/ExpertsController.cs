using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Services;
using HelpI.API.SeedWork.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Security.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _expertService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);
            return Ok(expertResource);
        }

        [HttpPut("{id}/profile")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] SaveExpertProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            ExpertProfile profile = new ExpertProfile(resource.Elo, resource.GameUserName, resource.ExperienceStory, resource.WhyMe, resource.StartedPlaying); 
            var result = await _expertService.UpdateProfileAsync(id, profile);

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
