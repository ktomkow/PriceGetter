using PriceGetter.Core.Models.ValueObjects;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.Factories
{
    public interface IPreProductFactory
    {
        PreProduct Create(Url productPage);

        Task<PreProduct> CreateAsync(Url productPage);
    }
}
