using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.DataProviders.Xkom;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PriceGetter.ContentProvider.Factories
{
    public class ImageUrlProviderFactory : IImageUrlProviderFactory
    {
        private readonly IEnumerable<IImageUrlProvider> providers;

        public ImageUrlProviderFactory(IEnumerable<IImageUrlProvider> providers)
        {
            this.providers = providers;
        }

        public IImageUrlProvider Create(Url productPage)
        {
            return this.providers.Single(x => x is IXkomImageUrlProvider);
        }
    }
}
