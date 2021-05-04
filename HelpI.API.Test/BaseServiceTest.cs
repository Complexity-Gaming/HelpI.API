using HelpI.API.Domain.Persistence.Repositories;
using Moq;
using NUnit.Framework;

namespace HelpI.API.Test
{
    public abstract class BaseServiceTest
    {
        protected Mock<IUnitOfWork> GetDefaultIUnitOfWOrkInstance()
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

        protected Mock<IPlayerTrainingMaterialRepository> GetDefaultIPlayerTrainingMaterialRepositoryRepositoryInstance()
        {
            return new Mock<IPlayerTrainingMaterialRepository>();
        }
    }
}