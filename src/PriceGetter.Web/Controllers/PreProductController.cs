using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Contracts.Products;
using PriceGetter.Web.Tools.Unbaser;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class PreProductController : AbstractController
    {
        private readonly IPreProductService preProductService;
        private readonly IUnbaser unbaser;

        public PreProductController(IPreProductService preProductService, IUnbaser unbaser)
        {
            this.preProductService = preProductService;
            this.unbaser = unbaser;
        }

        /// <summary>
        /// This method gets product details from the seller page.
        /// </summary>
        ///  <remarks>
        /// Sample url:
        /// 
        ///     aHR0cHM6Ly93d3cueC1rb20ucGwvcC81NjQ0NDctcHJvY2Vzb3J5LWludGVsLWNvcmUtaTUtaW50ZWwtY29yZS1pNS0xMDYwMGtmLmh0bWw=
        ///     
        /// </remarks>
        /// <param name="productUrlBase64">Product page encoded with base64</param>
        /// <returns>SellerSpecificDetailsDto</returns>
        [HttpGet]
        [Route("{productUrlBase64}")]
        public async Task<PreProductDto> GetDetails([FromRoute]string productUrlBase64)
        {
            string url = this.unbaser.Unbase(productUrlBase64);

            PreProductDto preProductDto = await this.preProductService.Get(url);
                
            return preProductDto;
        }
    }
}
