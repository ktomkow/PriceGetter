using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ServicesImplementation
{
    public class PricesWatcher : IPricesWatcher
    {
        private readonly IUnitOfWork unitOfWork;

        public PricesWatcher(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AnyWorkLeft()
        {
            var repo = this.unitOfWork.ProductRepository;
            var products = await repo.GetMonitored();

            if(products.Any(x => !x.Prices.Any()))
            {
                return true;
            }

            return products.Any(x => x.GetLastPrice().At.Date != DateTimeMethods.UtcNow().Date);
        }

        public Task CheckPriceOfRandomProduct()
        {
            throw new System.NotImplementedException();
        }
    }
}
