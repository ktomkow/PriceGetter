using PriceGetter.Core.Interfaces.DataProvider;
using PriceGetter.Core.Models.ValueObjects;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.DataProviders
{
    public interface IDataProvider : INameProvider, IPriceProvider, IImageUrlProvider
    {

    }
}
