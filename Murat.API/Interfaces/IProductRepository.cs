using System.Collections.Generic;
using System.Threading.Tasks;
using Murat.API.Data;

namespace Murat.API.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<Product> Create(Product product);
        public Task UpdateAsync(Product product);
        public Task RemoveAsync(int id);
    }
}
