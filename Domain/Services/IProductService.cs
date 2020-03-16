using System.Collections.Generic;
using System.Threading.Tasks;
using freecodecampapi.Domain.Models;
using freecodecampapi.Services.Communication;
using Microsoft.AspNetCore.Mvc;

namespace freecodecampapi.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> getAsync(int id);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> Update(int id, Product product);
        Task<ProductResponse> Delete(int id);
    }
}