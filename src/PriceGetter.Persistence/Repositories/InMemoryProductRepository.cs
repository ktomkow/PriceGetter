using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Persistence.Repositories
{
    public class InMemoryProductRepository : IProductRepository
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

        public async Task Save(Product product)
        {
            if(this.products.Contains(product) == false)
            {
                this.products.Add(product);
            }

            await Task.CompletedTask;
        }
    }
}
