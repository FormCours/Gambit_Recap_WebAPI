using Gambit.API.Contracts.Intput;
using Gambit.API.Contracts.Output;
using Gambit.API.Handlers;
using Gambit.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gambit.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductHandler _productHandler;

        public ProductController(ProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            ProductOutput product = _productHandler.Get(id);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]LimitOffsetParameters limitOffsetParameters)
        {
            IEnumerable<ProductListOutput> products = _productHandler.GetAll(limitOffsetParameters.Offset, limitOffsetParameters.Limit);

            return Ok(new
            {
                count = products.Count(),
                results = products
            });
        }


    }
}
