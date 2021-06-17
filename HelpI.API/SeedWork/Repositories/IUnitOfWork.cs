using System.Threading.Tasks;

namespace HelpI.API.SeedWork.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
