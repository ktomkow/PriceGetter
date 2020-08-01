using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public interface IProductService : IApplicationService
    {
        //Task<Guid> CreateProduct();
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
