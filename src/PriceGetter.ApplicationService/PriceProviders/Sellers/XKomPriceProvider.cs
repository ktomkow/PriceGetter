using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.PriceProviders.Sellers
{
    public class XKomPriceProvider : IPriceProvider
    {
        private readonly IHtmlContentGetter htmlContentGetter;
        private readonly PriceExtractorXkom priceExtractor;

        public XKomPriceProvider(
            IHtmlContentGetter htmlContentGetter,
            PriceExtractorXkom priceExtractor)
        {
            this.htmlContentGetter = htmlContentGetter;
            this.priceExtractor = priceExtractor;
        }

        public async Task<Money> Get(ProductFollow productFollow)
        {
            Html html = await this.htmlContentGetter.GetAsync(productFollow.ProductPage);

            Money money = this.priceExtractor.Extract(html);

            return money;
        }
    }
}
