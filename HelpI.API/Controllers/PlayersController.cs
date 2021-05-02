using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Services;
using HelpI.API.Extensions;
using HelpI.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlayerResource resource)
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
    }
}
