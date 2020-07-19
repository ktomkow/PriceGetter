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

        public void Clean()
        {
            throw new NotImplementedException();
        }
    }
}
