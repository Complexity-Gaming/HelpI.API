using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Training.Application.Transform.Resources;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Training.Controllers 
{
    [Route("/api/trainings")]
    [Produces("application/json")]
    [ApiController]
    public class TrainingMaterialsController : ControllerBase
    {
        private readonly ITrainingMaterialService _trainingMaterialService;
        private readonly IMapper _mapper;

        public TrainingMaterialsController(ITrainingMaterialService trainingMaterialService, IMapper mapper)
        {
            _trainingMaterialService = trainingMaterialService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrainingMaterialResource>), 200)]
        public async Task<IEnumerable<TrainingMaterialResource>> GetAllAsync()
        {
            var trainingMaterials = await _trainingMaterialService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TrainingMaterial>, IEnumerable<TrainingMaterialResource>>(trainingMaterials);
            return resources;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<TrainingMaterialResource>), 200)]
        public async Task<TrainingMaterialResource> GetTrainingByIdAsync(int id)
        {
            var training = await _trainingMaterialService.GetByIdAsync(id);
            var resource = _mapper.Map<TrainingMaterial, TrainingMaterialResource> (training);
            return resource;
        }
    }
}
