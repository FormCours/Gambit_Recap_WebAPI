using Gambit.API.Contracts.Output;
using Gambit.API.Mappers;
using Gambit.Domain.Exceptions;
using Gambit.Domain.Models;
using Gambit.Domain.Repositories;

namespace Gambit.API.Handlers
{
    public class ProductHandler
    {
        private readonly IProductRepository _repository;
        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductOutput> GetAsync(int id)
        {
            Product? product = await _repository.GetAsync(id);
            if(product is null)
            {
                throw new ProductNotFoundException();
            }

            return product.ToOutput();
        }

        public async IAsyncEnumerable<ProductListOutput> GetAllAsync(int offset, int limit)
        {
            await foreach (var product in _repository.GetAllAsync(offset, limit))
            {
                yield return ProductMapper.ToListOutput(product);
            }
        }
    }
}
