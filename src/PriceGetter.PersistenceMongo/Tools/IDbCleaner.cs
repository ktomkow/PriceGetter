using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.Tools
{
    public interface IDbCleaner
    {
        void Clean(string databaseName);
    }
}
