using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.DomainServices.PreProducts
{
    public interface IPreProductFactory
    {
        PreProduct Get(Url productPage);
    }
}
