using MongoDB.Bson;
using MongoDB.Driver;
using PriceGetter.Core.Entities;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.PersistenceMongo.DbModels;
using PriceGetter.PersistenceMongo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.PersistenceMongo.Repositories
{
    public class SellersMongoRepository : ISellersRepository
    {
        private readonly ICollectionProvider collectionProvider;

        public SellersMongoRepository(ICollectionProvider collectionProvider)
        {
            this.collectionProvider = collectionProvider;
        }

        public async Task<IEnumerable<Seller>> Get()
        {
            var collection = this.GetCollection();

            var data = await collection.FindAsync(new BsonDocument());

            return data.ToEnumerable().Select(x => x.ToSeller());
        }

        public async Task<Seller> Get(Guid sellerId)
        {
            var collection = this.GetCollection();
            string dbModelId = sellerId.ToString();

            var potentialSellers = await collection.FindAsync(x => x.Id == dbModelId);

            Seller seller = potentialSellers.ToEnumerable().Single().ToSeller();

            return seller;
        }

        public async Task Save(Seller seller)
        {
            var collection = this.GetCollection();
            SellerDbModel dbModel = new SellerDbModel(seller);
            var potentialSellers = await collection.FindAsync(x => x.Id == dbModel.Id);

            bool doesExist = potentialSellers.ToEnumerable().SingleOrDefault() != null;

            if(doesExist)
            {
                // update
                await collection.FindOneAndReplaceAsync(x => x.Id == dbModel.Id, dbModel);
            }
            else
            {
                // insert
                await collection.InsertOneAsync(dbModel);
            }
        }

        private IMongoCollection<SellerDbModel> GetCollection()
        {
            string collectionName = Collections.Sellers;

            return this.collectionProvider.Get<SellerDbModel>(collectionName);
        }
    }
}
