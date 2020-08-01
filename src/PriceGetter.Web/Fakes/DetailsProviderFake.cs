using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PriceGetter.Web.Fakes
{
    public class DetailsProviderFake : IDetailsProvider
    {
        public async Task<ProductFromSellerDetailsDto> GetAsync(string url)
        {
            await Task.Delay(200);
            ProductFromSellerDetailsDto result = new ProductFromSellerDetailsDto()
            {
                Name = "name",
                LastPrice = new PriceDto() { Price = 19.99m, At = new DateTime(1970,1,1,0,0,0)},
                ProductPage = url,
                Seller = "seller",
                ImageUrl = string.Empty
            };

            return result;
        }
    }
}
