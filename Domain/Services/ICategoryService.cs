using System.Collections.Generic;
using System.Threading.Tasks;
using freecodecampapi.Domain.Models;
using freecodecampapi.Services.Communication;

namespace freecodecampapi.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> getAsync(int id);
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}