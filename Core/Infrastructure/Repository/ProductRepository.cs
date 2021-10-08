using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository: IProductRepository
    {
        public Task<Products> GetProductByIDAsync(int Id) {
            throw new System.Exception();
        }

        public Task<IReadOnlyList<Products>> GetProductAsync()
        {
            throw new System.Exception();
        }
    }
}
