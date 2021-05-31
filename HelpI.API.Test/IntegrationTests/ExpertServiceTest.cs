using FluentAssertions;
using HelpI.API.Domain.Services.Communications;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpI.API.Application.Services.Security;
using HelpI.API.Domain.Models.Security;

namespace HelpI.API.Test.IntegrationTests
{
    public class ExpertServiceTest : BaseServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public async Task GetAllAsyncWhenNoExpertsReturnEmptyCollection()
        {
            // Arrange
            var mockExpertRepository = GetDefaultIExpertRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            mockExpertRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Expert>());

            var service = new ExpertService(mockUnitOfWork.Object, mockExpertRepository.Object);

            // Act

            List<Expert> result = (List<Expert>)await service.ListAsync();
            var expertsCount = result.Count;

            // Assert
            expertsCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsExpertNotFoundResponse()
        {
            // Arrange
            var mockExpertRepository = GetDefaultIExpertRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
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
