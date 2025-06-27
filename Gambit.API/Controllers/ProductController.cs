using Gambit.API.Contracts.Intput;
using Gambit.API.Contracts.Output;
using Gambit.API.Handlers;
using Gambit.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            ProductOutput product = await _productHandler.GetAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]LimitOffsetParameters limitOffsetParameters)
        {
            // IAsyncEnumerable pour renvoyé "IActionResult"
            // - Utiliser "ToBlockingEnumerable()" pour la transformé en IEnumerable
            // - Rendre la liste suspendable via le Nugget "System.Linq.Async" 

            IEnumerable<ProductListOutput> products = await _productHandler.GetAllAsync(limitOffsetParameters.Offset, limitOffsetParameters.Limit).ToListAsync();

            return Ok(new
            {
                count = products.Count(),
                results = products
            });

            // Pour faire du streaming de la liste, il faut renvoyer directement la IAsyncEnumerable
        }
    }
}
