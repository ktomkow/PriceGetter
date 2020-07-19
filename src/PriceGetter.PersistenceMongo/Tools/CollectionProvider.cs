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
        private static readonly string databaseName = "PriceGetter";

        public CollectionProvider(DatabaseSettings settings)
        {
            IMongoClient client = new MongoClient(settings.NoSqlConnectionString);
            this.database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> Get<T>(string collectionName)
        {
            return this.database.GetCollection<T>(collectionName);
        }
    }
}
