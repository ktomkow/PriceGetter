using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories
{
    // TODO: Check if it is reasonable and implement it
    public interface IDataProvidersAbstractFactory
    {
        //IDataProvidersFactory Create(Product product);

        IDataProvidersFactory Create(Url productPage);
    }
}
