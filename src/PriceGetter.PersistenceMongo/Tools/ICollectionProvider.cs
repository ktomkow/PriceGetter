using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.Tools
{
    public interface ICollectionProvider
    {
        IMongoCollection<T> Get<T>(string collectionName);
    }
}
