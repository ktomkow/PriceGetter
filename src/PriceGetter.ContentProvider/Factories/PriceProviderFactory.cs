using PriceGetter.ApplicationServices.PriceProviders.Sellers;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PriceGetter.ContentProvider.Factories
{
    public class PriceProviderFactory : IPriceProviderFactory
    {
        private readonly IEnumerable<IPriceProvider> providers;

        public PriceProviderFactory(IEnumerable<IPriceProvider> providers)
        {
            this.providers = providers;
        }

        public IPriceProvider Create(Url productPage)
        {
            return this.providers.Single(x => x is XKomPriceProvider);
        }
    }
}
