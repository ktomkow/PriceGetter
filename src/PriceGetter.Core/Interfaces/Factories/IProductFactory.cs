using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories
{
    public interface IProductFactory
    {
        Product Create(PreProduct preProduct);
    }
}
