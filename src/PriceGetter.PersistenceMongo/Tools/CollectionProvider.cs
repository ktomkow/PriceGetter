using MongoDB.Driver;
using PriceGetter.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.Tools
{
    public class CollectionProvider : ICollectionProvider
    {
        private readonly IMongoDatabase database;

        public CollectionProvider(MongoSettings settings)
        {
            IMongoClient client = new MongoClient(settings.ConnectionString);
            this.database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> Get<T>(string collectionName)
        {
            return this.database.GetCollection<T>(collectionName);
        }
    }
}
