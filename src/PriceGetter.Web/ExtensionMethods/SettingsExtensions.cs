using Microsoft.Extensions.Configuration;
using PriceGetter.Infrastructure.Settings;

namespace PriceGetter.Web.ExtensionMethods
{
    /// <summary>
    /// Class containing extension methods to make life easier
    /// </summary>
    public static class SettingsExtensions
    {
        /// <summary>
        /// Method that reads section of appsettings and binds it to a specified type
        /// </summary>
        /// <param name="configuration">Object to call method on</param>
        /// <typeparam name="T">Target type that holds settings from appsettings section. 
        /// Type name must ends with 'Settings', ex: LoggerSettings type will make the method try to read appsettings section "Logger".</typeparam>
        /// <returns>Instance of given class</returns>
        public static T GetSettings<T>(this IConfiguration configuration) where T : ISettings, new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);

            var settings = new T();
            
            configuration.GetSection(section).Bind(settings);

            return settings;
        }
    }
}
