using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories.DataProviders
{
    public interface IDataProviderFactory
    {
        IDataProvider Create(Url productPage);
    }
}
