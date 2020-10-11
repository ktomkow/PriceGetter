﻿using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
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
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Create(CreateProductCommand command)
        {
            var productName = new Name(command.Name);

            Product product = new Product(productName);

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
                        Amount = price.Amount.ValuAsDecimal                    
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
