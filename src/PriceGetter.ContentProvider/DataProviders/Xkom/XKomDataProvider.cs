using PriceGetter.ApplicationServices.PriceProviders.Sellers;
using PriceGetter.ContentProvider.DataProviders.Xkom;
using PriceGetter.Core.Interfaces.DataProvider;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.XKom
{
    public class XKomDataProvider : IDataProvider
    {
        private readonly IPriceProvider priceProvider;
        private readonly INameProvider nameProvider;
        private readonly IImageUrlProvider imageUrlProvider;

        public XKomDataProvider(
            XKomPriceProvider priceProvider, 
            XKomNameProvider nameProvider, 
            XKomImageProvider imageUrlProvider,
            ICacheFacade cache)
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
