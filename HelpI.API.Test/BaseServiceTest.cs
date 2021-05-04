using HelpI.API.Domain.Persistence.Repositories;
using Moq;
using NUnit.Framework;

namespace HelpI.API.Test
{
    public abstract class BaseServiceTest<T>
    {
        protected Mock<IUnitOfWork> GetDefaultIUnitOfWOrkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}