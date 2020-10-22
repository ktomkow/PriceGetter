using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories.DataProviders
{
    public interface IImageUrlProviderFactory
    {
        IImageUrlProvider GetProvider(Url productPage);
    }
}
