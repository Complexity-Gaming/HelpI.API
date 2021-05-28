using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Services;
using HelpI.API.Application.Extensions;
using HelpI.API.Application.Transform.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Training;

namespace HelpI.API.Interfaces.Training.Rest
{
    [Route("/api/experts/{expertId}/trainings")]
    public class ExpertTrainingMaterialsController : ControllerBase
    {
        private readonly ITrainingMaterialService _trainingMaterialService;
        private readonly IMapper _mapper;

        public ExpertTrainingMaterialsController(ITrainingMaterialService trainingMaterialService, IMapper mapper)
        {
            _trainingMaterialService = trainingMaterialService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<TrainingMaterialResource>> GetAllByExpertIdAsync(int expertId)
        {
            var trainingMaterials = await _trainingMaterialService.ListByExpertIdAsync(expertId);
            var resources = _mapper.Map<IEnumerable<TrainingMaterial>, IEnumerable<TrainingMaterialResource>>(trainingMaterials);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PublishTrainingMaterialAsync(int expertId, [FromBody] SaveTrainingMaterialResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var trainingMaterial = _mapper.Map<SaveTrainingMaterialResource, TrainingMaterial>(resource);
            var result = await _trainingMaterialService.PublishTrainingMaterialAsync(expertId, trainingMaterial);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainingMaterialResource = _mapper.Map<TrainingMaterial, TrainingMaterialResource>(result.Resource);

            return Ok(trainingMaterialResource);

        }
    }
}
