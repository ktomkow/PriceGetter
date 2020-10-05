using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Persistence.Repositories
{
    public class InMemoryProductRepository : IProductsRepository
    {
        private List<Product> products;

        public InMemoryProductRepository()
        {
            this.products = new List<Product>();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await Task.FromResult(this.products.ToList());
        }

        public async Task<Product> Get(Guid productId)
        {
            return await Task.FromResult(this.products.Single(x => x.Id == productId));
        }

        public async Task Add(Product product)
        {
            if(this.products.Contains(product) == false)
            {
                this.products.Add(product);
            }

            await Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetMonitored()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(Name name)
        {
            throw new NotImplementedException();
        }
    }
}
