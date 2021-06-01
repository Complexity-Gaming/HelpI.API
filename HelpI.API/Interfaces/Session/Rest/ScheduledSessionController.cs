using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Application.Transform.Resources.Session;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Services.Session;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Interfaces.Session.Rest
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ScheduledSessionController: ControllerBase
    {
        private readonly IScheduledSessionService _scheduledSessionService;
        private readonly IMapper _mapper;

        public ScheduledSessionController(IScheduledSessionService scheduledSessionService, IMapper mapper)
        {
            _scheduledSessionService = scheduledSessionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ScheduledSessionResource>), 200)]
        public async Task<IEnumerable<ScheduledSessionResource>> GetAllAsync()
        {
            var scheduledSessions = await _scheduledSessionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ScheduledSession>, IEnumerable<ScheduledSessionResource>>(scheduledSessions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ScheduledSessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _scheduledSessionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var scheduledSessionResource = _mapper.Map<ScheduledSession, ScheduledSessionResource>(result.Resource);
            return Ok(scheduledSessionResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _scheduledSessionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var scheduledSessionResource = _mapper.Map<ScheduledSession, ScheduledSessionResource>(result.Resource);
            return Ok(scheduledSessionResource);
        }
    }
}