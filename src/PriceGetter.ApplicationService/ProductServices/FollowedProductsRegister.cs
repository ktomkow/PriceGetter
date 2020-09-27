using PriceGetter.ApplicationServices.PriceProviders;
using PriceGetter.Core.Entities;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public class FollowedProductsRegister : IFollowedProductsRegister
    {
        private readonly IProductRepository productRepository;
        private readonly ISellersRepository sellersRepository;
        private readonly IFollowedProductRepository followedProductRepository;
        private readonly IPriceProviderFactory priceProviderFactory;
        private readonly IPriceGetterLogger logger;

        public FollowedProductsRegister(
            IProductRepository productRepository,
            ISellersRepository sellersRepository,
            IFollowedProductRepository followedProductRepository,
            IPriceProviderFactory priceProviderFactory,
            IPriceGetterLogger logger)
        {
            this.productRepository = productRepository;
            this.sellersRepository = sellersRepository;
            this.followedProductRepository = followedProductRepository;
            this.priceProviderFactory = priceProviderFactory;
            this.logger = logger;
        }

        public async Task RegisterPrices()
        {
            Task<IEnumerable<ProductFollow>> getFollowed = this.followedProductRepository.Get();

            IEnumerable<Seller> sellers = await this.sellersRepository.Get();

            IEnumerable<ProductFollow> followedProducts = await getFollowed;

            foreach (ProductFollow follow in followedProducts)
            {
                try
                {
                    Seller seller = sellers.Single(x => x.Id == follow.SellerId);
                    Product product = await this.productRepository.Get(follow.ProductId);
                    IPriceProvider priceProvider = this.priceProviderFactory.GetProvider(seller);
                    Money amount = await priceProvider.Get(follow);
                    product.AddPrice(amount, seller);
                    await this.productRepository.Add(product);
                }
                catch(Exception e)
                {
                    logger.Error(e, "Error during getting price");
                    follow.Deactivate();
                    await this.followedProductRepository.Add(follow);
                }
            }
        }
    }
}
