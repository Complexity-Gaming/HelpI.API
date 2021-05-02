using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Services;
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
    }
}
