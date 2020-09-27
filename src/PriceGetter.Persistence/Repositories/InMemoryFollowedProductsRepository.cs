using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Persistence.Repositories
{
    public class InMemoryFollowedProductsRepository : IFollowedProductRepository
    {
        private List<ProductFollow> followedProducts;

        public InMemoryFollowedProductsRepository()
        {
            this.followedProducts = new List<ProductFollow>();
        }

        public async Task<IEnumerable<ProductFollow>> Get()
        {
            return await Task.FromResult(this.followedProducts.ToList());
        }

        public async Task Add(ProductFollow productFollow)
        {
            if(this.followedProducts.Contains(productFollow) == false)
            {
                this.followedProducts.Add(productFollow);
            }

            await Task.CompletedTask;
        }
    }
}
