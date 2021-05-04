using FluentAssertions;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Services;
using HelpI.API.Domain.Services.Communications;
using HelpI.API.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpI.API.Test
{
    public class ExpertServiceTest : BaseServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public async Task GetAllAsync_WhenNoExperts_ReturnEmptyCollection()
        {
            // Arrange
            var mockExpertRepository = GetDefaultIExpertRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWOrkInstance();

            mockExpertRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Expert>());

            var service = new ExpertService(mockUnitOfWork.Object, mockExpertRepository.Object);

            // Act

            List<Expert> result = (List<Expert>)await service.ListAsync();
            var expertsCount = result.Count;

            // Assert
            expertsCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsync_WhenInvalidId_ReturnsExpertNotFoundResponse()
        {
            // Arrange
            var mockExpertRepository = GetDefaultIExpertRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWOrkInstance();
            var expertId = 1;
            mockExpertRepository.Setup(r => r.FindById(expertId)).Returns(Task.FromResult<Expert>(null));
            var service = new ExpertService(mockUnitOfWork.Object, mockExpertRepository.Object);

            // Act
            ExpertResponse result = await service.GetByIdAsync(expertId);
            var message = result.Message;

            //Assert
            message.Should().Be("Expert Not Found");
        }


    }
}
