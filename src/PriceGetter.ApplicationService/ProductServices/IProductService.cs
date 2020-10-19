using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    [Obsolete]
    public interface IProductService : IApplicationService
    {
        Task<IEnumerable<ProductDto>> Get();

        Task<Guid> Create(CreateProductCommand command);
    }
}
