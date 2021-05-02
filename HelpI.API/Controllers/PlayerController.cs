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
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerResource>> GetAllAsync()
        {
            var players = await _playerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResource>>(players);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlayerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var player = _mapper.Map<SavePlayerResource, Player>(resource);
            var result = await _playerService.SaveAsync(player);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var playerResource = _mapper.Map<Player, PlayerResource>(result.Resource);

            return Ok(playerResource);
        }

    }
}
