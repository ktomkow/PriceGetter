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
        public async Task<SellerSpecificDetailsDto> GetAsync(string url)
        {
            await Task.Delay(200);
            SellerSpecificDetailsDto result = new SellerSpecificDetailsDto()
            {
                Name = "name",
                CurrentPrice = 19.99m,
                ProductPage = url,
                Seller = "seller",
                ImageUrl = string.Empty
            };

            return result;
        }
    }
}
