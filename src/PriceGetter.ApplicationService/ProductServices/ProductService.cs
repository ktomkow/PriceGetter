using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            IEnumerable<Product> products = await this.unitOfWork.ProductRepository.Get();
            List<ProductDto> productsDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                ProductDto productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name.ToString()
                };

                List<PriceDto> prices = new List<PriceDto>();
                foreach (var price in product.Prices)
                {
                    PriceDto priceDto = new PriceDto()
                    {
                        At = price.At,
                        Price = price.Amount.ValuAsDecimal                    
                    };

                    prices.Add(priceDto);
                }

                productDto.Prices = prices;
                productsDtos.Add(productDto);
            }

            return productsDtos;
        }
    }
}
