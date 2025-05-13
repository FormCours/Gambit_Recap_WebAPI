using Gambit.API.Contracts.Output;
using Gambit.Domain.Models;

namespace Gambit.API.Mappers
{
    public static class ProductMapper
    {

        public static ProductOutput ToOutput(this Product product)
        {
            return new ProductOutput()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                IsAvailable = product.IsAvailable,
                Tags = product.Tags,
                Desc = product.Desc
            };
        }

        public static ProductListOutput ToListOutput(this Product product)
        {
            return new ProductListOutput()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }

    }
}
