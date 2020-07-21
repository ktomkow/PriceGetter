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
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            IEnumerable<Product> products = await this.productRepository.Get();
            List<ProductDto> productsDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                ProductDto productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name.ToString()
                };

                List<PriceDto> prices = new List<PriceDto>();
                foreach (var price in product.PriceHistory)
                {
                    PriceDto priceDto = new PriceDto()
                    {
                        At = price.At,
                        Price = price.Amount.Value,
                        SellerId = price.SellerId
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
