using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.WebClients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders.Sellers
{
    public class XkomDetailsProvider : ISpecificDetailsProvider
    {
        private readonly IHtmlContentGetter htmlGetter;

        public XkomDetailsProvider(IHtmlContentGetter htmlGetter)
        {
            this.htmlGetter = htmlGetter;
        }

        public async Task<SellerSpecificDetails> GetAsync(Url url)
        {
            Html content = await this.htmlGetter.GetAsync(url);

            throw new NotImplementedException();
        }
    }
}
