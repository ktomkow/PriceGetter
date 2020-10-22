using PriceGetter.ContentProvider.DataProviders.Xkom;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PriceGetter.ContentProvider.Factories
{
    public class NameProviderFactory : INameProviderFactory
    {
        private readonly IEnumerable<INameProvider> providers;

        public NameProviderFactory(IEnumerable<INameProvider> providers)
        {
            this.providers = providers;
        }

        public INameProvider Create(Url productPage)
        {
            return this.providers.Single(x => x is XKomNameProvider);
        }
    }
}
