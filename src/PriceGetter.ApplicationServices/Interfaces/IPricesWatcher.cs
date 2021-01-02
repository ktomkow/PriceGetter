using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.Interfaces
{
    public interface IPricesWatcher
    {
        Task CheckPriceOfRandomProduct();

        Task<bool> AnyWorkLeft();
    }
}
