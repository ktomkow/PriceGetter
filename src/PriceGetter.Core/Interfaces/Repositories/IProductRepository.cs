using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(Guid productId);
        Task Save(Product product);
    }
}
