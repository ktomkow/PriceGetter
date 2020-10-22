using PriceGetter.ContentProvider.DataProviders.XKom;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PriceGetter.ContentProvider.Factories
{
    public class DataProviderFactory : IDataProviderFactory
    {
        private readonly IEnumerable<IDataProvider> providers;

        public DataProviderFactory(IEnumerable<IDataProvider> providers)
        {
            this.providers = providers;
        }

        public IDataProvider Create(Url productPage)
        {
            return this.providers.Single(x => x is XKomDataProvider);
        }
    }
}
