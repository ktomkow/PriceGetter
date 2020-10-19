using PriceGetter.ApplicationServices.PriceProviders.Sellers;
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
        private readonly XKomPriceProvider priceProvider;
        private readonly INameProvider nameProvider;
        private readonly IImageUrlProvider imageUrlProvider;
        private readonly ICacheFacade cache;

        public XKomDataProvider(
            XKomPriceProvider priceProvider, 
            INameProvider nameProvider, 
            IImageUrlProvider imageUrlProvider,
            ICacheFacade cache)
        {
            this.priceProvider = priceProvider;
            this.nameProvider = nameProvider;
            this.imageUrlProvider = imageUrlProvider;
            this.cache = cache;
        }

        public Task<Url> GetImageUrl(Url productPage)
        {
            throw new NotImplementedException();
        }

        public Task<Name> GetName(Url productPage)
        {
            throw new NotImplementedException();
        }

        public Task<Money> GetPrice(Url productPage)
        {
            throw new NotImplementedException();
        }
    }
}
