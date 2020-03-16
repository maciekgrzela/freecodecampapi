using System.Collections.Generic;
using System.Threading.Tasks;
using freecodecampapi.Domain.Models;
using freecodecampapi.Domain.Persistence.Contexts;
using freecodecampapi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace freecodecampapi.Domain.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext _context) : base(_context) { }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}