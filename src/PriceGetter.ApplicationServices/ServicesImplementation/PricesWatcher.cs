using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ServicesImplementation
{
    public class PricesWatcher : IPricesWatcher
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDataProviderFactory dataProviderFactory;

        public PricesWatcher(IUnitOfWork unitOfWork, IDataProviderFactory dataProviderFactory)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.dataProviderFactory = dataProviderFactory ?? throw new ArgumentNullException(nameof(dataProviderFactory));
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

        public async Task CheckPriceOfRandomProduct()
        {
            if(await this.AnyWorkLeft() == false)
            {
                return;
            }

            Product product = await this.GetRandomProduct();

            var dataProvider = this.dataProviderFactory.Create(product.ProductPage);
            var price = await dataProvider.GetPrice(product.ProductPage);

            product.AddPrice(price);

            await this.unitOfWork.CommitAsync();
        }

        private async Task<Product> GetRandomProduct()
        {
            var repo = this.unitOfWork.ProductRepository;
            var products = await repo.GetMonitored();
            var product = products.First(x => x.GetLastPrice().At.Date != DateTimeMethods.UtcNow().Date);

            return product;
        }
    }
}
