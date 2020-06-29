using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Settings
{
    public class SqlDatabaseSettings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}
