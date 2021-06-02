using AutoMapper;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Services.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Application.Extensions;
using HelpI.API.Application.Transform.Resources;
using HelpI.API.Domain.Models.Security;

namespace HelpI.API.Interfaces.Application.Rest
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ExpertApplicationController: ControllerBase
    {
        private readonly IExpertApplicationService _expertApplicationService;
        private readonly IMapper _mapper;

        public ExpertApplicationController(IExpertApplicationService expertApplicationService, IMapper mapper)
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
