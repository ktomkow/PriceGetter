using Microsoft.AspNetCore.Mvc;
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
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task Create([FromBody] CreateProductCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await this.unitOfWork.ProductRepository.Get();

            return Ok(products);
        }
    }
}
