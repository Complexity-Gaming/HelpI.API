using NUnit.Framework;
using Moq;
using FluentAssertions;
using HelpI.API.Application;
using System.Threading.Tasks;
using HelpI.API.Security.Application.Services;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Services.Communication;

namespace HelpI.API.Test.IntegrationTests
{
    public class PlayerServiceTest : BaseServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        //GetByIdAsync
        [Test]
        public async Task GetByIdAsyncWhenPlayerDoesNotExistReturnsPlayerNotFoundResponse()
        {
            var mockPlayerRepository = GetDefaultIPlayerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockTrainingMaterialRepository = GetDefaultIPlayerTrainingMaterialRepositoryInstance();
            var playerId = -1;
            mockPlayerRepository.Setup(r => r.FindById(playerId)).Returns(Task.FromResult<Player>(null));
            var service = new PlayerService(mockPlayerRepository.Object, mockUnitOfWork.Object, mockTrainingMaterialRepository.Object);

            PlayerResponse result = await service.GetByIdAsync(playerId);
            var message = result.Message;

            message.Should().Be("Player not found");
        }

        //DeleteAsync

        [Test]
        public async Task DeleteAsyncWhenPlayerDoesNotExistsReturnsPlayerResponse()
        {
            var mockPlayerRepository = GetDefaultIPlayerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockTrainingMaterialRepository = GetDefaultIPlayerTrainingMaterialRepositoryInstance();
            var playerId = -1;

            mockPlayerRepository.Setup(r => r.FindById(playerId)).Returns(Task.FromResult<Player>(null));
            var service = new PlayerService(mockPlayerRepository.Object, mockUnitOfWork.Object, mockTrainingMaterialRepository.Object);

            PlayerResponse result = await service.GetByIdAsync(playerId);
            var message = result.Message;

            message.Should().Be("Player not found");
        }

        [Test]
        public async Task DeleteAsyncWhenPlayerExistsReturnsNull()
        {
            var mockPlayerRepository = GetDefaultIPlayerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockTrainingMaterialRepository = GetDefaultIPlayerTrainingMaterialRepositoryInstance();
            var playerId = 1;

            mockPlayerRepository.Setup(r => r.FindById(playerId)).Returns(Task.FromResult<Player>(null));
            var service = new PlayerService(mockPlayerRepository.Object, mockUnitOfWork.Object, mockTrainingMaterialRepository.Object);

            PlayerResponse result = await service.DeleteAsync(playerId);

            result.Resource.Should().BeNull();
        }

        //UpdateAsync

        [Test]
        public async Task UpdateAsyncWhenPlayerDoesNotExistReturnPlayerResponse()
        {
            var mockPlayerRepository = GetDefaultIPlayerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockTrainingMaterialRepository = GetDefaultIPlayerTrainingMaterialRepositoryInstance();
            var playerId = -1;

            mockPlayerRepository.Setup(r => r.FindById(playerId)).Returns(Task.FromResult<Player>(null));
            var service = new PlayerService(mockPlayerRepository.Object, mockUnitOfWork.Object, mockTrainingMaterialRepository.Object);

            PlayerResponse result = await service.GetByIdAsync(playerId);
            var message = result.Message;

            message.Should().Be("Player not found");
        }
       
        private Mock<PlayerResponse> GetDefaultPlayerResponseInstance()
        {
            return new Mock<PlayerResponse>();
        }
    }
}