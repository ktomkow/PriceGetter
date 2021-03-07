using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.Interfaces
{
    public interface IProductService : IApplicationService
    {
        Task<IEnumerable<ProductDto>> Get();

        Task<ProductDto> Get(Guid productId);

        Task<ProductDto> GetUniquePrices(Guid productId);

        Task<Guid> Create(CreateProductCommand command);
    }
}
