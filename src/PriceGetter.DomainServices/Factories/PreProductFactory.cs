using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PriceGetter.DomainServices.Factories
{
    public class PreProductFactory : IPreProductFactory
    {
        private readonly IDataProviderFactory dataProviderFactory;

        public PreProductFactory(IDataProviderFactory dataProviderFactory)
        {
            this.dataProviderFactory = dataProviderFactory ?? throw new ArgumentNullException(nameof(dataProviderFactory));
        }

        public PreProduct Create(Url productPage)
        {
            PreProduct preProduct = this.CreateAsync(productPage).Result;

            return preProduct;
        }

        public async Task<PreProduct> CreateAsync(Url productPage)
        {
            if(productPage is null)
            {
                throw new ArgumentNullException(nameof(productPage));
            }

            IDataProvider dataProvider = this.dataProviderFactory.Create(productPage);

            Money price = await dataProvider.GetPrice(productPage);
            Url imageUrl = await dataProvider.GetImageUrl(productPage);
            Name name = await dataProvider.GetName(productPage);

            PreProduct preProduct = new PreProduct(name, price, productPage, imageUrl);

            return preProduct;
        }
    }
}
