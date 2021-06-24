using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.Security.Domain.Services;
using HelpI.API.Security.Domain.Services.Communication;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.SeedWork.Settings;
using HelpI.API.Training.Domain.Persistence.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BCryptNet = BCrypt.Net;

namespace HelpI.API.Security.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerTrainingMaterialRepository _playerTrainingMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public PlayerService(IPlayerRepository playerRepository, IUnitOfWork unitOfWork, IPlayerTrainingMaterialRepository playerTrainingMaterialRepository, IOptions<AppSettings> appSettings)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
            _playerTrainingMaterialRepository = playerTrainingMaterialRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<PlayerResponse> DeleteAsync(int id)
        {
            var existingPlayer = await _playerRepository.FindById(id);

            if (existingPlayer == null)
                return new PlayerResponse("Player not found");

            try
            {
                _playerRepository.Remove(existingPlayer);
                await _unitOfWork.CompleteAsync();

                return new PlayerResponse(existingPlayer);
            }
            catch(Exception ex)
            {
                return new PlayerResponse($"An error ocurred while deleting player: {ex.Message}");
            }

        }

        public async Task<PlayerResponse> GetByIdAsync(int id)
        {
            var existingPlayer = await _playerRepository.FindById(id);

            if (existingPlayer == null)
                return new PlayerResponse("Player not found");
            return new PlayerResponse(existingPlayer);
        }

        public async Task<IEnumerable<Player>> ListAsync()
        {
            return await _playerRepository.ListAsync(); 
        }

        public async Task<IEnumerable<Player>> ListByTrainingMaterialIdAsync(int trainingMaterialId)
        {
            var playerTrainingMaterials = await _playerTrainingMaterialRepository.ListByTrainingMaterialIdAsync(trainingMaterialId);
            var players = playerTrainingMaterials.Select(pt => pt.Player).ToList();
            return players;
        }

        public async Task<PlayerResponse> SaveAsync(Player player)
        {
            var existingPlayer = await _playerRepository.FindByEmailAsync(player.Email);
            if (existingPlayer != null)
                throw new ApplicationException("Email '" + player.Email + "' is already taken");
            
            player.Id = await _playerRepository.GetNewIdAsync();
            player.Password = BCryptNet.BCrypt.HashPassword(player.Password);
            try
            {
                await _playerRepository.AddAsync(player);
                await _unitOfWork.CompleteAsync();
                return new PlayerResponse(player);
            }
            catch(Exception ex)
            {
                return new PlayerResponse($"An error occurred while saving player: {ex.Message}");
            }
        }

        public async Task<PlayerResponse> UpdateAsync(int id, Player player)
        {
            var existingPlayer = await _playerRepository.FindById(id);

            if (existingPlayer == null)
                return new PlayerResponse("Player not found");
            
            existingPlayer.Email = player.Email;
            
            try
            {
                _playerRepository.Update(existingPlayer);
                await _unitOfWork.CompleteAsync();

                return new PlayerResponse(existingPlayer);
            }
            catch (Exception ex)
            {
                return new PlayerResponse($"An error ocurred while deleting player: {ex.Message}");
            }
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var player = await _playerRepository.FindByEmailAsync(request.Email);
            if (player == null || !BCryptNet.BCrypt.Verify(request.Password, player.Password))
            {
                throw new ApplicationException("Email or password ir incorrect");
            }
            var token = GenerateJwtToken(player);
            return new AuthenticationResponse(player, token);
        }

        private string GenerateJwtToken(Player player)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, player.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
