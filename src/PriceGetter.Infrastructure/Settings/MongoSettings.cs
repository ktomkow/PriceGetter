using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Settings
{
    public class MongoSettings : ISettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public bool IsInitialized()
        {
            Func<string, bool> isInitialized = x => string.IsNullOrWhiteSpace(x) == false;
            return isInitialized(this.ConnectionString) && isInitialized(this.DatabaseName);
        }
    }
}
