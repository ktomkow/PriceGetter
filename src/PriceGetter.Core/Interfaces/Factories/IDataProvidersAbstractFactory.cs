using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories
{
    public interface IDataProvidersAbstractFactory
    {
        IDataProvidersFactory Create(Product product);

        IDataProvidersFactory Create(Url productPage);
    }
}
