using AutoMapper;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Services.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Interfaces.Application.Rest
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CoachApplicationController: ControllerBase
    {
        private readonly ICoachApplicationService _coachApplicationService;
        private readonly IMapper _mapper;

        public CoachApplicationController(ICoachApplicationService coachApplicationService, IMapper mapper)
        {
            _coachApplicationService = coachApplicationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CoachApplicationResource>),200)]
        public async Task<IEnumerable<CoachApplicationResource>> GetAllAsync()
        {
            var applications = await _coachApplicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CoachApplication>, IEnumerable<CoachApplicationResource>>(applications);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CoachApplicationResource),200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _coachApplicationService.GetByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var coachApplicationResourse = _mapper.Map<CoachApplication, CoachApplicationResource>(result.Resource);
            return Ok(coachApplicationResourse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _coachApplicationService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var expertResource = _mapper.Map<CoachApplication, CoachApplicationResource>(result.Resource);
            return Ok(expertResource);
        }
    }
}
