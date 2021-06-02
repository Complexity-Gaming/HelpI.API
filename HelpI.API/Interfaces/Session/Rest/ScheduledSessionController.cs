using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Application.Extensions;
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
        //todo: Move StartSession function from SessionService to Schedule Session Service
        private readonly IScheduledSessionService _scheduledSessionService;
        private readonly IIndividualSessionService _individualSessionService;
        private readonly IMapper _mapper;

        public ScheduledSessionController(IScheduledSessionService scheduledSessionService, IMapper mapper, IIndividualSessionService individualSessionService)
        {
            _scheduledSessionService = scheduledSessionService;
            _mapper = mapper;
            _individualSessionService = individualSessionService;
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

        [HttpPost]
        public async Task<ActionResult> ScheduleSession([FromBody] SaveScheduledSessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var schedule = _mapper.Map<SaveScheduledSessionResource, ScheduledSession>(resource);
            var result = await _scheduledSessionService.ScheduleSession(schedule);
            if (!result.Success)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<ScheduledSession, ScheduledSessionResource>(result.Resource);

            return Ok(scheduleResource);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> StartSession(int id)
        {
            var result = await _individualSessionService.StartSession(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<IndividualSession, IndividualSessionResource>(result.Resource);
            return Ok(scheduleResource);
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