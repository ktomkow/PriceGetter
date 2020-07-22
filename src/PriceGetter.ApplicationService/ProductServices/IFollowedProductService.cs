using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public interface IFollowedProductService
    {
        Task<ProductFromSellerDetailsDto> GetSpecificProduct(Guid followedProductId);
    }
}
