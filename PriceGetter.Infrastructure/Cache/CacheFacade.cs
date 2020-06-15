using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Cache
{
    public class CacheFacade : ICacheFacade
    {
        private static Dictionary<int, object> dictionary = new Dictionary<int, object>();

        public TItem Get<TItem>(object key)
        {
            try
            {
                int keyHashCode = key.GetHashCode();
                if (dictionary.TryGetValue(keyHashCode, out object @object))
                {
                    return (TItem)@object;
                }
            }
            catch(Exception) { }

            return default;
        }

        public void Save<TItem>(TItem obj, object key)
        {
            int keyHashCode = key.GetHashCode();
            if (dictionary.ContainsKey(keyHashCode))
            {
                dictionary.Remove(keyHashCode);
            }

            dictionary.Add(keyHashCode, obj);
        }
    }
}
