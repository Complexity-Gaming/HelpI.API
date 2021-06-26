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
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class PlayersController : ControllerBase
    {

        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlayerResource>), 200)]
        public async Task<IEnumerable<PlayerResource>> GetAllAsync()
        {
            var players = await _playerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResource>>(players);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExpertResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult),404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _playerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var playerResource = _mapper.Map<Player, PlayerResource>(result.Resource);
            return Ok(playerResource);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] SavePlayerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var player = _mapper.Map<SavePlayerResource, Player>(resource);
            var result = await _playerService.SaveAsync(player);

            if (!result.Success)
                return BadRequest(result.Message);

            var playerResource = _mapper.Map<Player, PlayerResource>(result.Resource);

            return Ok(playerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlayerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var player = _mapper.Map<SavePlayerResource, Player>(resource);
            var result = await _playerService.UpdateAsync(id, player);

            if (!result.Success)
                return BadRequest(result.Message);

            var playerResource = _mapper.Map<Player, PlayerResource>(result.Resource);

            return Ok(playerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _playerService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var playerResource = _mapper.Map<Player, PlayerResource>(result.Resource);
            return Ok(playerResource);
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = await _playerService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }
    }
}
