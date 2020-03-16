using System.Threading.Tasks;
using freecodecampapi.Domain.Persistence.Contexts;
using freecodecampapi.Domain.Repositories;

namespace freecodecampapi.Domain.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}