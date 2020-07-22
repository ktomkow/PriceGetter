using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public class FollowedProductService : IFollowedProductService
    {
        private readonly IFollowedProductRepository followedRepository;

        public FollowedProductService(IFollowedProductRepository followedRepository)
        {
            this.followedRepository = followedRepository;
        }

        public Task<ProductFromSellerDetailsDto> GetSpecificProduct(Guid followedProductId)
        {
            throw new NotImplementedException();
        }
    }
}
