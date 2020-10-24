using PriceGetter.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Cache
{
    public class CacheFacade : ICacheFacade
    {
        private static Dictionary<int, (object, DateTime)> dictionary = new Dictionary<int, (object, DateTime)>();
        private readonly IPriceGetterLogger logger;
        private TimeSpan period = TimeSpan.FromMinutes(180);

        public CacheFacade(IPriceGetterLogger logger)
        {
            this.logger = logger;
        }

        public TItem Get<TItem>(object key)
        {
            this.logger.Information("Yeah, getting from cache!");

            int keyHashCode = this.ConvertObjectToKey(key);

            if(dictionary.TryGetValue(keyHashCode, out (object, DateTime) @object))
            {
                try
                {
                    if (DateTime.UtcNow > @object.Item2.Add(this.period))
                    {
                        return default;
                    }

                    TItem instance = (TItem)@object.Item1;
                    return instance;
                }
                catch(InvalidCastException)
                {
                    return default;
                }
            }

            return default;
        }

        public string Get(object key) 
        {
            int keyHashCode = this.ConvertObjectToKey(key);

            if (dictionary.TryGetValue(keyHashCode, out (object, DateTime) @object))
            {
                return string.Empty;
            }

            return default;
        }

        public void Reset<TIem>(object key)
        {
            int keyHashCode = this.ConvertObjectToKey(key);
            dictionary.Remove(keyHashCode);
        }

        public void Save<TItem>(TItem obj, object key)
        {
            int keyHashCode = this.ConvertObjectToKey(key);
            if (dictionary.ContainsKey(keyHashCode))
            {
                dictionary.Remove(keyHashCode);
            }

            dictionary.Add(keyHashCode, (obj, DateTime.UtcNow));
        }

        private int ConvertObjectToKey(object key)
        {
            try
            {
                int keyHashCode = key.GetHashCode();
                return keyHashCode;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch (Exception) 
            {
                throw new ArgumentException(nameof(key));
            }
        }
    }
}
