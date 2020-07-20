using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.SellerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class SellersController : AbstractController
    {
        private readonly ISellerService sellerService;

        public SellersController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Create([FromRoute]string name)
        {
            await this.sellerService.AddSeller(name, "http://xkom-.pl");

            return Ok();
        }
    }
}
