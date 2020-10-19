using PriceGetter.Core.Models.ValueObjects;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces
{
    public interface IHtmlContentGetter
    {
        Task<Html> GetAsync(Url url);
    }
}
