using Gambit.Domain.Models;

namespace Gambit.Domain.Repositories
{
    public interface IProductRepository
    {
        Product? Get(int id);
        IEnumerable<Product> GetAll(int offset, int limit);
        Product Create(Product product);
        Product Update(Product product);
        bool Delete(int id);
    }
}
