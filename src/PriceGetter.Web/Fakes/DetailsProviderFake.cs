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
        public async Task<PreProductDto> GetAsync(string url)
        {
            await Task.Delay(200);
            PreProductDto result = new PreProductDto()
            {
                Name = "name",
                Price = 19.99m,
                ProductPage = url,
                ImageUrl = string.Empty
            };

            return result;
        }
    }
}
