using PriceGetter.Core.Interfaces.DataProvider;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories
{
    public interface IDataProvidersFactory
    {
        IPriceProvider PriceProvider();

        INameProvider NameProvider();

        IImageUrlProvider ImageUrlProvider();
    }
}
