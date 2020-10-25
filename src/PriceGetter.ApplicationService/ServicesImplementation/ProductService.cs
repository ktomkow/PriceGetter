using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Core.SimpleTypesConverters.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ServicesImplementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Create(CreateProductCommand command)
        {
            var productName = new Name(command.Name);
            var productPage = Url.FromString(command.ProductPage);

            Product product = new Product(productName, productPage);

            product.AddPrice(new Money(command.Price));
            product.ChangeImageUrl(Url.FromString(command.ImageUrl));

            await this.unitOfWork.ProductRepository.Add(product);

            await this.unitOfWork.CommitAsync();

            return product.Id;
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            IEnumerable<Product> products = await this.unitOfWork.ProductRepository.Get();
            List<ProductDto> productsDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                ProductDto productDto = this.Map(product);

                productsDtos.Add(productDto);
            }

            return productsDtos;
        }

        public async Task<ProductDto> Get(Guid productId)
        {
            Product product = await this.unitOfWork.ProductRepository.Get(productId);
            ProductDto dto = this.Map(product);
            return dto;
        }

        private ProductDto Map(Product product)
        {
            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name.ToString(),
                ImageUrl = product.ProductImage.ToString(),
                ProductPage = product.ProductPage.ToString()
            };

            List<PriceDto> prices = new List<PriceDto>();
            foreach (var price in product.Prices)
            {
                PriceDto priceDto = new PriceDto()
                {
                    At = price.At,
                    Amount = price.Amount.ValueAsDecimal
                };

                prices.Add(priceDto);
            }

            productDto.Prices = prices;

            return productDto;
        }
    }
}
