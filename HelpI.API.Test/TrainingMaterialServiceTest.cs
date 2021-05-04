using FluentAssertions;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Persistence.Repositories;
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
    public class TrainingMaterialServiceTest : BaseServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public async Task GetAllAsyncWhenNoTrainingMaterialsReturnEmptyCollection()
        {
            // Arrange
            var mockTrainingMaterialRepository = GetDefaultITrainingMaterialRepositoryInstance();
            var mockPlayerTrainingMaterialRepository = GetDefaultIPlayerTrainingMaterialRepositoryInstance();
            var mockExpertRepository = GetDefaultIExpertRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            mockTrainingMaterialRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<TrainingMaterial>());

            var service = new TrainingMaterialService(
                mockTrainingMaterialRepository.Object, mockUnitOfWork.Object, mockExpertRepository.Object, mockPlayerTrainingMaterialRepository.Object);

            // Act

            List<TrainingMaterial> result = (List<TrainingMaterial>)await service.ListAsync();
            var trainingMaterialsCount = result.Count;

            // Assert
            trainingMaterialsCount.Should().Equals(0);
        }
       
    }
}
