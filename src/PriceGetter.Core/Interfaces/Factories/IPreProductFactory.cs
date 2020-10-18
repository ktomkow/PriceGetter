using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories
{
    public interface IPreProductFactory
    {
        PreProduct Create(Name name, Url productPage, Url imageUrl);
    }
}
