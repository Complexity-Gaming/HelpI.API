using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Application.Application.Transform.Resources;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Application.Domain.Services;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.SeedWork.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Application.Controllers
{
    [Route("/api/applications")]
    [Produces("application/json")]
    [ApiController]
    public class ExpertApplicationsController: ControllerBase
    {
        private readonly IExpertApplicationService _expertApplicationService;
        private readonly IMapper _mapper;

        public ExpertApplicationsController(IExpertApplicationService expertApplicationService, IMapper mapper)
        {
            _expertApplicationService = expertApplicationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpertApplicationResource>),200)]
        public async Task<IEnumerable<ExpertApplicationResource>> GetAllAsync()
        {
            var applications = await _expertApplicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ExpertApplication>, IEnumerable<ExpertApplicationResource>>(applications);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExpertApplicationResource),200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _expertApplicationService.GetByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var coachApplicationResourse = _mapper.Map<ExpertApplication, ExpertApplicationResource>(result.Resource);
            return Ok(coachApplicationResourse);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ReviewApplication(int id, [FromBody] ReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var result = await _expertApplicationService.ReviewApplicationAsync(id, resource.Review, resource.ReviewComment);
            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);

            return Ok(expertResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _expertApplicationService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<ExpertApplication, ExpertApplicationResource>(result.Resource);
            return Ok(expertResource);
        }
    }
}
