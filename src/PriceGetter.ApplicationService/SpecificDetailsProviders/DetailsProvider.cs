using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders
{
    public class DetailsProvider : IDetailsProvider
    {
        private readonly ISpecificDetailsProviderFactory factory;

        public DetailsProvider(ISpecificDetailsProviderFactory specificDetailsProviderFactory)
        {
            this.factory = specificDetailsProviderFactory;
        }

        public async Task<SellerSpecificDetailsDto> GetAsync(string url)
        {
            ISpecificDetailsProvider provider = this.factory.Get(url);

            Url productUrl = new Url(url);

            SellerSpecificDetailsDto specificDetailsDto = await provider.GetAsync(productUrl);

            return specificDetailsDto;
        }
    }
}
