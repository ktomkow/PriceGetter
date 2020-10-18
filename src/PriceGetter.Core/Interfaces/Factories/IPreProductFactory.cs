using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories
{
    public interface IPreProductFactory
    {
        PreProduct Create(Url imageUrl);
    }
}
