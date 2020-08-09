using Microsoft.AspNetCore.Mvc;
using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class ProductController : AbstractController
    {
        [HttpPost]
        public async Task Create([FromBody] CreateProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
