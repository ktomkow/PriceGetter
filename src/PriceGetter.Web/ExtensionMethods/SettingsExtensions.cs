using Microsoft.Extensions.Configuration;
using PriceGetter.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.ExtensionMethods
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : ISettings, new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);

            return configurationValue;
        }
    }
}
