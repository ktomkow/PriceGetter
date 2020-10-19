using PriceGetter.Core.Models.ValueObjects;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.DataProviders
{
    public interface INameProvider
    {
        Task<Name> GetName(Url productPage);
    }
}
