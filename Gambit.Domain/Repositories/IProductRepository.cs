using Gambit.Domain.Models;

namespace Gambit.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetAsync(int id);
        IAsyncEnumerable<Product> GetAllAsync(int offset, int limit);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
