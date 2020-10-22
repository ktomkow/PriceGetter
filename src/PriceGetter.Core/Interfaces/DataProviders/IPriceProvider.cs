using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.DataProviders
{
    public interface IPriceProvider
    {
        Task<Money> GetPrice(Url productPage);
   }
}
