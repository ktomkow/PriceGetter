using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface IFollowedProductRepository
    {
        Task<IEnumerable<ProductFollow>> Get();
        Task Save(ProductFollow productFollow);
    }
}
