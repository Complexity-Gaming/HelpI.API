using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Application;
using HelpI.API.Domain.Persistence.Repositories.Security;
using HelpI.API.Domain.Persistence.Repositories.Training;
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
    }
}