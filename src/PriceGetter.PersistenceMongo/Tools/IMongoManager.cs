using PriceGetter.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.Tools
{
    public interface IMongoManager // to be created in integration tests module
    {
        bool DoesDatabaseExist(MongoSettings dbSettings);
        bool CreateDatabase(MongoSettings dbSettings);
        bool RemoveDatabase(MongoSettings dbSettings);

        bool DoesCollectionExists(string collectionName);
        bool CreateCollection(string collectionName);
        bool RemoveCollection(string collectionName);
    }
}
