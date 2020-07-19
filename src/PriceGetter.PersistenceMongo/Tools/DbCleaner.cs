using MongoDB.Bson;
using MongoDB.Driver;
using PriceGetter.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.Tools
{
    public class DbCleaner : IDbCleaner
    {
        private readonly CollectionProvider collectionProvider;

        public DbCleaner(CollectionProvider collectionProvider)
        {
            this.collectionProvider = collectionProvider;
        }

        public void Clean()
        {
            IEnumerable<string> collections = Collections.All();

            foreach (var collectionName in collections)
            {
                var collection = this.collectionProvider.Get<object>(collectionName);
                collection.DeleteMany(new BsonDocument());
            }
        }
    }
}
