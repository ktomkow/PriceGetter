using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.ProductServices;
using PriceGetter.Core.Entities;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.PersistenceMongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class TmpController : AbstractController
    {
        private readonly IProductRepository productRepository;
        private readonly ISellersRepository sellersRepository;
        private readonly IFollowedProductRepository followedProductRepository;
        private readonly IFollowedProductsRegister register;
        private readonly DatabaseSettings dbSettings;

        public TmpController(
            IProductRepository productRepository,
            ISellersRepository sellersRepository,
            IFollowedProductRepository followedProductRepository,
            IFollowedProductsRegister register,
            DatabaseSettings dbSettings)
        {
            this.productRepository = productRepository;
            this.sellersRepository = sellersRepository;
            this.followedProductRepository = followedProductRepository;
            this.register = register;
            this.dbSettings = dbSettings;
        }

        [HttpGet]
        public IActionResult Get()
        {
            StringBuilder builder = new StringBuilder();

            var collections = Collections.All();

            foreach (var item in collections)
            {
                builder.AppendLine(item);
            }

            return Ok(builder.ToString());
        }

        [Route("sampleJob")]
        [HttpGet]
        public IActionResult SampleJob()
        {
            throw new Exception("safety-valve");

            string url = "https://www.x-kom.pl/p/564447-procesory-intel-core-i5-intel-core-i5-10600kf.html";

            Seller seller = new Seller(new Name("xkom"), SellerSystem.xkom);
            this.sellersRepository.Save(seller);

            Product product = new Product(new Name("procek i5"));
            this.productRepository.Save(product);

            ProductFollow follow = new ProductFollow(product, seller, new Url(url));
            this.followedProductRepository.Save(follow);

            this.register.RegisterPrices();

            Thread.Sleep(5000);

            var products = this.productRepository.Get().Result;

            return Ok(products);
        }
    }
}
