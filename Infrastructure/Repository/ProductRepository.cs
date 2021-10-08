using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) {
            _context = context;
        }
        public async Task<Products> GetProductByIDAsync(int Id) {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Products>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
           
        }
    }
}
