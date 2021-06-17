using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Games.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GamesController: ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<GameModel>> GetAllAsync()
        {
            var resources = await _gameService.GetAllAsync();
            return resources;
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetGameAsync(int id)
        {
            var result = await _gameService.GetGameByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}