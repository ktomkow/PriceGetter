using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.ProductServices;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.PersistenceMongo;
using PriceGetter.PersistenceMongo.Tools;
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
        private readonly IProductsRepository productRepository;
        private readonly SqlSettings dbSettings;
        private readonly IDbCleaner dbCleaner;
        private readonly ICollectionProvider collectionProvider;

        public TmpController(
            IProductsRepository productRepository,
            SqlSettings dbSettings,
            IDbCleaner dbCleaner,
            ICollectionProvider collectionProvider)
        {
            this.productRepository = productRepository;
            this.dbSettings = dbSettings;
            this.dbCleaner = dbCleaner;
            this.collectionProvider = collectionProvider;
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

        [HttpPost]
        public IActionResult SampleDb()
        {
            Sample dupa = new Sample("dupa");
            this.collectionProvider.Get<Sample>("Sellers").InsertOne(dupa);
            return Ok();
        }

        [HttpDelete]
        public IActionResult ClearDb()
        {
            this.dbCleaner.Clean();

            return NoContent();
        }
        
        public class Sample
        {
            public Guid Id { get; set; }
            public string Dupa { get; set; }

            public Sample(string dupa)
            {
                this.Dupa = dupa;
                this.Id = Guid.NewGuid();
            }
        }
    }
}
