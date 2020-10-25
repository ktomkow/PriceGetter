using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Contracts.Products;
using System;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class ProductController : AbstractController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await this.productService.Get();

            return Ok(products);
        }

        [HttpGet]
        [Route("{idAsString}")]
        public async Task<IActionResult> Get([FromRoute] string idAsString)
        {
            Guid id = Guid.Parse(idAsString);
            var product = await this.productService.Get(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            Guid productId = await this.productService.Create(command);

            return Created($"{Url.RouteUrl(productId)}/{productId}", null);
        }
    }
}
