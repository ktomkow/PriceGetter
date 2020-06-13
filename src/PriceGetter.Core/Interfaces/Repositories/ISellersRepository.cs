using PriceGetter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface ISellersRepository : IRepository
    {
        Task<IEnumerable<Seller>> Get();
        Task<Seller> Get(Guid sellerId);
        Task Save(Seller seller);
    }
}
