using PriceGetter.Core.Interfaces.DataProvider;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces
{
    public interface IPriceProviderFactory
    {
        IPriceProvider GetProvider(Url productPage);

        IPriceProvider GetProvider(Product produt);
    }
}
