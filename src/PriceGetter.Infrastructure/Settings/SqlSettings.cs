using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Settings
{
    public class SqlSettings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}
