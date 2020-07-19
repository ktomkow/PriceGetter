using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Settings
{
    public class DatabaseSettings : ISettings
    {
        public string SqlConnectionString { get; set; }
        public string NoSqlConnectionString { get; set; }
    }
}
