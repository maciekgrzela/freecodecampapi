using freecodecampapi.Domain.Persistence.Contexts;

namespace freecodecampapi.Domain.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext _context)
        {
            this._context = _context;
        }
    }
}