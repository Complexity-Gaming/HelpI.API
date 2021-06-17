using HelpI.API.Application.Domain.Persistence.Repository;
using HelpI.API.Games.Domain.Persistence.Repository;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Training.Domain.Persistence.Repositories;
using Moq;
using NUnit.Framework;

namespace HelpI.API.Test.IntegrationTests
{
    public abstract class BaseServiceTest
    {
        protected Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        protected Mock<IExpertRepository> GetDefaultIExpertRepositoryInstance()
        {
            return new Mock<IExpertRepository>();
        }
        protected Mock<ITrainingMaterialRepository> GetDefaultITrainingMaterialRepositoryInstance()
        {
            return new Mock<ITrainingMaterialRepository>();
        }

        protected Mock<IPlayerTrainingMaterialRepository> GetDefaultIPlayerTrainingMaterialRepositoryInstance()
        {
            return new Mock<IPlayerTrainingMaterialRepository>();
        }
        protected Mock<IPlayerRepository> GetDefaultIPlayerRepositoryInstance()
        {
            return new Mock<IPlayerRepository>();
        }
        
        protected Mock<IExpertApplicationRepository> GetDefaultIExpertApplicationRepositoryInstance()
        {
            return new Mock<IExpertApplicationRepository>();
        }
        protected Mock<IGameRepository> GetDefaultIGameRepositoryInstance()
        {
            return new Mock<IGameRepository>();
        }
    }
}