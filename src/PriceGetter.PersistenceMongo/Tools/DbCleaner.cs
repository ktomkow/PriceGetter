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
        private readonly DatabaseSettings dbSettings;

        public DbCleaner(DatabaseSettings dbSettings)
        {
            this.dbSettings = dbSettings;
        }

        public void Clean(string databaseName)
        {
            IEnumerable<string> collections = Collections.All();

            var client = new MongoClient(this.dbSettings.NoSqlConnectionString);
            var database = client.GetDatabase(databaseName);

            foreach (var collectionName in collections)
            {
                var collection = database.GetCollection<object>(collectionName);
                collection.DeleteMany(new BsonDocument());
            }

            throw new NotImplementedException();
        }
    }
}
