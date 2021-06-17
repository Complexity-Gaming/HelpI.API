using HelpI.API.SeedWork.Contexts;

namespace HelpI.API.SeedWork.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
