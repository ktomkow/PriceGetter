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
        private readonly MongoSettings dbSettings;

        public DbCleaner(MongoSettings dbSettings)
        {
            this.dbSettings = dbSettings;
        }

        public void Clean()
        {
            IEnumerable<string> collections = Collections.All();

            var client = new MongoClient(this.dbSettings.ConnectionString);
            var database = client.GetDatabase(this.dbSettings.DatabaseName);

            foreach (var collectionName in collections)
            {
                var collection = database.GetCollection<object>(collectionName);
                collection.DeleteMany(new BsonDocument());
            }
        }
    }
}
