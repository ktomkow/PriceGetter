using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Interfaces.Repositories;
using System;
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

            DateTime today = DateTimeMethods.UtcNow().Date;
            bool result = products.Any(x => x.GetLastPrice().At.Date != today);
            return result;
        }

        public Task CheckPriceOfRandomProduct()
        {
            throw new System.NotImplementedException();
        }
    }
}
