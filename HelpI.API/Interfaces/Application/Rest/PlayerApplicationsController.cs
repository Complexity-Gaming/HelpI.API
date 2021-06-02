using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Application.Extensions;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Services.Application;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Interfaces.Application.Rest
{
    [Route("api/players/{playerId}/applications")]
    [Produces("application/json")]
    [ApiController]
    public class PlayerApplicationsController : ControllerBase
    {
        private readonly IExpertApplicationService _expertApplicationService;
        private readonly IMapper _mapper;

        public PlayerApplicationsController(IExpertApplicationService expertApplicationService, IMapper mapper)
        {
            _expertApplicationService = expertApplicationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ExpertApplicationResource>> GetAllByApplicantIdAsync(int playerId)
        {
            var expertApplications = await _expertApplicationService.ListByApplicantIdAsync(playerId);
            var resources = _mapper.Map<IEnumerable<ExpertApplication>, IEnumerable<ExpertApplicationResource>>(expertApplications);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> SendApplicationAsync(int playerId, [FromBody] SaveExpertApplicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var expertApplication = _mapper.Map<SaveExpertApplicationResource, ExpertApplication>(resource);
            var result = await _expertApplicationService.SendExpertApplication(playerId, expertApplication);

            if (!result.Success)
                return BadRequest(result.Message);

            var expertApplicationResource = _mapper.Map<ExpertApplication, ExpertApplicationResource>(result.Resource);

            return Ok(expertApplicationResource);

        }
    }
}