using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.ProductServices;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var newIdentifier = await this.productService.Create(command);

            return Created("http://dupa.pl",null);
        }
    }
}
