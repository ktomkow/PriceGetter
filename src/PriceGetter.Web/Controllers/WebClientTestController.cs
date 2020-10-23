using Microsoft.AspNetCore.Mvc;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Web.Tools.Unbaser;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class WebClientTestController : AbstractController
    {
        private readonly IUnbaser unbaser;
        private readonly IHtmlContentGetter htmlContentGetter;

        public WebClientTestController(IUnbaser unbaser, IHtmlContentGetter htmlContentGetter)
        {
            this.unbaser = unbaser;
            this.htmlContentGetter = htmlContentGetter;
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
        public async Task<string> Test([FromRoute] string productUrlBase64)
        {
            string urlAsString = this.unbaser.Unbase(productUrlBase64);

            Url url = PriceGetter.Core.Models.ValueObjects.Url.FromString(urlAsString);

            Html html = await this.htmlContentGetter.GetAsync(url);

            return html.RawContent;
        }
    }
}
