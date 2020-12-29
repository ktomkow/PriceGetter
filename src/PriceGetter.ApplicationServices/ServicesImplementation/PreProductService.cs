using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ServicesImplementation
{
    public class PreProductService : IPreProductService
    {
        private readonly IPreProductFactory preProductFactory;

        public PreProductService(IPreProductFactory preProductFactory)
        {
            this.preProductFactory = preProductFactory ?? throw new ArgumentNullException(nameof(preProductFactory));
        }

        public async Task<PreProductDto> Get(string productPage)
        {
            Url url = Url.FromString(productPage);

            PreProduct preProduct = await this.preProductFactory.CreateAsync(url);

            PreProductDto preProductDto = this.Map(preProduct);

            return preProductDto;
        }

        private PreProductDto Map(PreProduct preProduct)
        {
            PreProductDto dto = new PreProductDto();

            dto.Name = preProduct.Name.ToString();
            dto.ProductPage = preProduct.ProductPage.ToString();
            dto.ImageUrl = preProduct.ImageUrl.ToString();
            dto.Price = preProduct.Price.ValueAsDecimal;

            return dto;
        }
    }
}
