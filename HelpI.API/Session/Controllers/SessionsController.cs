using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.SeedWork.Extensions;
using HelpI.API.Session.Application.Transform.Resource;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Session.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ICoachingSessionService _coachingSessionService;
        private readonly IMapper _mapper;

        public SessionsController(ICoachingSessionService coachingSessionService, IMapper mapper)
        {
            _coachingSessionService = coachingSessionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CoachingSessionResource>), 200)]
        public async Task<IEnumerable<CoachingSessionResource>> GetAllAsync()
        {
            var individualSessions = await _coachingSessionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CoachingSession>, IEnumerable<CoachingSessionResource>>(individualSessions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CoachingSessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _coachingSessionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var individualSessionResource = _mapper.Map<CoachingSession, CoachingSessionResource>(result.Resource);
            return Ok(individualSessionResource);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> EndSession(int id,[FromBody] CoachingSessionReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _coachingSessionService.EndSession(id, new SessionReview(resource.Comment, resource.Review));
            if (!result.Success)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<CoachingSession, CoachingSessionResource>(result.Resource);

            return Ok(scheduleResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _coachingSessionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var individualSessionResource = _mapper.Map<CoachingSession, CoachingSessionResource>(result.Resource);
            return Ok(individualSessionResource);
        }
    }
}
