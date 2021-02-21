using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface IProductsRepository : IRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<IEnumerable<Product>> GetMonitored();
        Task<Product> Get(Guid productId);
        Task<Product> Get(Name name);
        Task Add(Product product);
        void Remove(Product product);
    }
}
