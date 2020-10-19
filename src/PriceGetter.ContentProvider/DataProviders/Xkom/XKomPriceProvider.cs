using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.Core.Interfaces.DataProvider;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

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

        public async Task<Money> GetPrice(Url productPage)
        {
            Html html = await this.htmlContentGetter.GetAsync(productPage);

            Money money = this.priceExtractor.Extract(html);

            return money;
        }

        public async Task<Money> Get(Product product)
        {
            return await this.GetPrice(product.ProductPage);
        }
    }
}
