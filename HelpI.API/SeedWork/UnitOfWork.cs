using System.Threading.Tasks;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;

namespace HelpI.API.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
