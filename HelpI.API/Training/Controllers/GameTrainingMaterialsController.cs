using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Training.Application.Transform.Resources;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Training.Controllers
{
    [ApiController]
    [Route("/api/games/{gameId}/trainings")]
    public class GameTrainingMaterialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITrainingMaterialService _trainingMaterialService;

        public GameTrainingMaterialsController(IMapper mapper, ITrainingMaterialService trainingMaterialService)
        {
            _mapper = mapper;
            _trainingMaterialService = trainingMaterialService;
        }

        [HttpGet]
        public async Task<IEnumerable<TrainingMaterialResource>> GetAllTrainingsByGameId(int gameId)
        {
            var trainings = await _trainingMaterialService.ListByGameIdAsync(gameId);
            var resources =
                _mapper.Map<IEnumerable<TrainingMaterial>, IEnumerable<TrainingMaterialResource>>(trainings);
            return resources;
        }
    }
}