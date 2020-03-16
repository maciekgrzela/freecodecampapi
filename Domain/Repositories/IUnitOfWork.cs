using System.Threading.Tasks;

namespace freecodecampapi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}