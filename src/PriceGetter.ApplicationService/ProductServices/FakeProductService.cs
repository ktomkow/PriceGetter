using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public class FakeProductService : IProductService
    {
        private readonly Random random;

        public FakeProductService()
        {
            this.random = new Random();
        }

        public async Task<Guid> Create(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            List<ProductDto> list = new List<ProductDto>();

            for (int i = 0; i < this.random.Next(6) + 6; i++)
            {
                var productDto = new ProductDto()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Product{i}",
                    ProductPage = "https://google.com",
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/02/16/13/42/box-2071537_960_720.png",
                    Prices = this.GetPrices()
                };

                list.Add(productDto);
            }

            return await Task.FromResult(list);
        }

        private IEnumerable<PriceDto> GetPrices()
        {
            List<PriceDto> list = new List<PriceDto>();

            for (int i = 0; i < this.random.Next(40) + 10; i++)
            {
                var price = new PriceDto()
                {
                    Amount = (decimal)(random.Next(1000) * random.NextDouble()),
                    At = DateTime.Now.AddDays(-random.Next(500))
                };

                list.Add(price);
            }

            return list;
        }
    }
}
