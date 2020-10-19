using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PriceGetter.DomainServices.Factories
{
    public class PreProductFactory : IPreProductFactory
    {
        private readonly IDataProvider dataProvider;

        public PreProductFactory(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider ?? throw new ArgumentNullException();
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

            Money price = await this.dataProvider.GetPrice(productPage);
            Url imageUrl = await this.dataProvider.GetImageUrl(productPage);
            Name name = await this.dataProvider.GetName(productPage);

            PreProduct preProduct = new PreProduct(name, price, productPage, imageUrl);

            return preProduct;
        }
    }
}
