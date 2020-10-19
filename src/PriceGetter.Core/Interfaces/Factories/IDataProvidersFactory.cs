using PriceGetter.Core.Interfaces.DataProvider;
using PriceGetter.Core.Interfaces.DataProviders;

namespace PriceGetter.Core.Interfaces.Factories
{
    // TODO: Check if it is reasonable and implement it
    public interface IDataProvidersFactory
    {
        IPriceProvider PriceProvider();

        INameProvider NameProvider();

        IImageUrlProvider ImageUrlProvider();
    }
}
