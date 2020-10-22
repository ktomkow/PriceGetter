using PriceGetter.ContentProvider.DataProviders;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces.DataProviders.Xkom;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.PriceProviders.Sellers
{
    public class XKomPriceProvider : HtmlDataProviderBase, IXkomPriceProvider
    {
        private readonly IPriceExtractor priceExtractor;

        public XKomPriceProvider(
            IXkomPriceExtractor priceExtractor,
            IHtmlContentGetter htmlContentGetter,
            ICacheFacade cache) : base(htmlContentGetter, cache)
        {
            this.priceExtractor = priceExtractor;
        }

        public async Task<Money> GetPrice(Url productPage)
        {
            if(productPage is null)
            {
                throw new ArgumentNullException(nameof(productPage));
            }

            Html html = await this.TakeThroughCache(productPage);

            Money money = this.priceExtractor.Extract(html);

            return money;
        }

        public async Task<Money> Get(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return await this.GetPrice(product.ProductPage);
        }
    }
}
