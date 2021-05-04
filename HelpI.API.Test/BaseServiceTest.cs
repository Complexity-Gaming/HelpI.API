using HelpI.API.Domain.Persistence.Repositories;
using Moq;
using NUnit.Framework;

namespace HelpI.API.Test
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
    }
}