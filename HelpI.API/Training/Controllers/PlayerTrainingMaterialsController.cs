using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Training.Application.Transform.Resources;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Training.Controllers
{
    [Route("api/players/{playerId}/trainings")]
    [Produces("application/json")]
    [ApiController]
    public class PlayerTrainingMaterialsController : ControllerBase
    {
        private readonly IPlayerTrainingMaterialService _playerTrainingMaterialService;
        private readonly ITrainingMaterialService _trainingMaterialService;
        private readonly IMapper _mapper;

        public PlayerTrainingMaterialsController(
            ITrainingMaterialService trainingMaterialService, IMapper mapper, IPlayerTrainingMaterialService playerTrainingMaterialService)
        {
            _trainingMaterialService = trainingMaterialService;
            _mapper = mapper;
            _playerTrainingMaterialService = playerTrainingMaterialService;
        }
        [HttpGet]
        public async Task<IEnumerable<TrainingMaterialResource>> GetAllByPlayerIdAsync(int playerId)
        {
            var trainingMaterials = await _trainingMaterialService.ListByPlayerIdAsync(playerId);
            var resources = _mapper.Map<IEnumerable<TrainingMaterial>, IEnumerable<TrainingMaterialResource>>(trainingMaterials);
            return resources;
        }
        [HttpPost("{trainingMaterialId}")]
        public async Task<IActionResult> PlayerPurchaseTrainingMaterialAsync(int playerId, int trainingMaterialId)
        {
            var result = await _playerTrainingMaterialService.PlayerPurchaseTrainingMaterial(playerId, trainingMaterialId);
            if (!result.Success)
                return BadRequest(result.Message);

            var trainingMaterialResource = _mapper.Map<TrainingMaterial, TrainingMaterialResource>(result.Resource.TrainingMaterial);
            return Ok(trainingMaterialResource);
        }
    }
}
