using PriceGetter.Core.Entities;
using PriceGetter.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Persistence.Repositories
{
    public class InMemorySellersRepository : ISellersRepository
    {
        private List<Seller> sellers;

        public InMemorySellersRepository()
        {
            this.sellers = new List<Seller>();
        }

        public async Task<IEnumerable<Seller>> Get()
        {
            return await Task.FromResult(this.sellers.ToList());
        }

        public async Task<Seller> Get(Guid sellerId)
        {
            return await Task.FromResult(this.sellers.Single(x => x.Id == sellerId));
        }

        public async Task Add(Seller seller)
        {
            if (this.sellers.Contains(seller) == false)
            {
                this.sellers.Add(seller);
            }

            await Task.CompletedTask;
        }
    }
}
