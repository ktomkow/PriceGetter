using PriceGetter.Core.Models.ValueObjects;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.DataProviders
{
    public interface IImageUrlProvider
    {
        Task<Url> GetImageUrl(Url productPage);
    }
}
