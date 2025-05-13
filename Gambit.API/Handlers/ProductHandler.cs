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

        public ProductOutput Get(int id)
        {
            Product? product = _repository.Get(id);
            if(product is null)
            {
                throw new ProductNotFoundException();
            }

            return product.ToOutput();
        }

        public IEnumerable<ProductListOutput> GetAll(int offset, int limit)
        {
            IEnumerable<Product> products = _repository.GetAll(offset, limit);

            //return products.Select(p => p.ToListOutput());
            return products.Select(ProductMapper.ToListOutput);
        }
    }
}
