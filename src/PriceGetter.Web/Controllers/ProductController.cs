using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Contracts.Products;
using System;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    /// <summary>
    /// Product related operations controller.
    /// </summary>
    public class ProductController : AbstractController
    {
        private readonly IProductService productService;

        /// <summary>
        /// Public constructor of the object. Has some dependencies to be satisfied.
        /// </summary>
        /// <param name="productService">Products service.</param>
        public ProductController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        /// <summary>
        /// Gets all products existing in the system.
        /// </summary>
        /// <returns>Collection of the product dto.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await this.productService.Get();

            return Ok(products);
        }

        /// <summary>
        /// Gets a specific product by its identifier.
        /// </summary>
        /// <param name="idAsString">Product identifier, guid as string.</param>
        /// <returns>Product dto.</returns>
        [HttpGet]
        [Route("{idAsString}")]
        public async Task<IActionResult> Get([FromRoute] string idAsString)
        {
            Guid id = Guid.Parse(idAsString);
            var product = await this.productService.Get(id);

            return Ok(product);
        }

        /// <summary>
        /// Created a new product using some input parameters (probably returned by other endpoint).
        /// </summary>
        /// <param name="command">Set of parameters to create product.</param>
        /// <returns>Status code of operation and link to new product if it was created.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            Guid productId = await this.productService.Create(command);

            return Created($"{Url.RouteUrl(productId)}/{productId}", null);
        }
    }
}
