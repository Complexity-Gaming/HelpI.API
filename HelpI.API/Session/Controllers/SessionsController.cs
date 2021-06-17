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
        private readonly IIndividualSessionService _individualSessionService;
        private readonly IMapper _mapper;

        public SessionsController(IIndividualSessionService individualSessionService, IMapper mapper)
        {
            _individualSessionService = individualSessionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IndividualSessionResource>), 200)]
        public async Task<IEnumerable<IndividualSessionResource>> GetAllAsync()
        {
            var individualSessions = await _individualSessionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<IndividualSession>, IEnumerable<IndividualSessionResource>>(individualSessions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IndividualSessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _individualSessionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var individualSessionResource = _mapper.Map<IndividualSession, IndividualSessionResource>(result.Resource);
            return Ok(individualSessionResource);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> EndSession(int id,[FromBody] SessionCalificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _individualSessionService.EndSession(id, new SessionCalification(resource.Comment, resource.Calification));
            if (!result.Success)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<IndividualSession, IndividualSessionResource>(result.Resource);

            return Ok(scheduleResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _individualSessionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var individualSessionResource = _mapper.Map<IndividualSession, IndividualSessionResource>(result.Resource);
            return Ok(individualSessionResource);
        }
    }
}
