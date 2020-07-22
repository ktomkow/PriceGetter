using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public class FollowedProductService : IFollowedProductService
    {
        private readonly IFollowedProductRepository followedRepository;
        private readonly IProductRepository productRepository;

        public FollowedProductService(IFollowedProductRepository followedRepository, IProductRepository productRepository)
        {
            this.followedRepository = followedRepository;
            this.productRepository = productRepository;
        }

        public async Task<ProductFromSellerDetailsDto> GetSpecificProduct(Guid followedProductId)
        {
            var followedProducts = await this.followedRepository.Get();
            ProductFollow productFollow = followedProducts.Single(x => x.Id == followedProductId);

            Product product = await this.productRepository.Get(productFollow.ProductId);
            Price lastPrice = product.LastPrice;

            throw new NotImplementedException();
        }
    }
}
