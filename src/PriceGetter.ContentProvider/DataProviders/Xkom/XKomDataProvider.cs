using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.DataProviders.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.XKom
{
    public class XKomDataProvider : IXkomDataProvider
    {
        private readonly IPriceProvider priceProvider;
        private readonly INameProvider nameProvider;
        private readonly IImageUrlProvider imageUrlProvider;

        public XKomDataProvider(
            IXkomPriceProvider priceProvider, 
            IXkomNameProvider nameProvider, 
            IXkomImageUrlProvider imageUrlProvider)
        {
            this.priceProvider = priceProvider ?? throw new ArgumentNullException(nameof(priceProvider));
            this.nameProvider = nameProvider ?? throw new ArgumentNullException(nameof(nameProvider));
            this.imageUrlProvider = imageUrlProvider ?? throw new ArgumentNullException(nameof(imageUrlProvider));
        }

        public async Task<Url> GetImageUrl(Url productPage)
        {
            return await this.imageUrlProvider.GetImageUrl(productPage);
        }

        public async Task<Name> GetName(Url productPage)
        {
            return await this.nameProvider.GetName(productPage);
        }

        public async Task<Money> GetPrice(Url productPage)
        {
            return await this.priceProvider.GetPrice(productPage);
        }
    }
}
