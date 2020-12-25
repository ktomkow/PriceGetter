using System;

namespace PriceGetter.Quartz.Configuration
{
    internal static class TypeExtensions
    {
        internal static string TriggerKey(this Type type)
        {
            return $"{type.FullName}.trigger";
        }
    }
}