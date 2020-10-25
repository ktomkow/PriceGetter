using PriceGetter.Contracts.Products;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.Interfaces
{
    public interface IPreProductService : IApplicationService
    {
        Task<PreProductDto> Get(string productPage);
    }
}
