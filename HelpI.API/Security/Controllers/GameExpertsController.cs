using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelpI.API.Security.Application.Services;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpI.API.Security.Controllers
{ 
    [Route("/api/games/{gameId}/experts")]
    [ApiController]
    public class GameExpertsController : ControllerBase
    {
        private readonly IExpertService _expertService;
        private readonly IMapper _mapper;

        public GameExpertsController(IExpertService expertService, IMapper mapper)
        {
            _expertService = expertService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ExpertResource>> GetAllExpertsByGameId(int gameId)
        {
            var experts = await _expertService.ListByGameIdAsync(gameId);
            var resources = _mapper.Map<IEnumerable<Expert>, IEnumerable<ExpertResource>>(experts);
            return resources;
        }
    }
}