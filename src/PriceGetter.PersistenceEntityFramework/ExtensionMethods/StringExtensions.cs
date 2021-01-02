namespace PriceGetter.PersistenceEntityFramework.ExtensionMethods
{
    internal static class StringExtensions
    {
        internal static string ToStringNullIfEmpty(this object obj)
        {
            if(obj is null)
            {
                return null;
            }

            string objToString = obj.ToString();

            if(string.IsNullOrWhiteSpace(objToString))
            {
                return null;
            }

            return objToString;
        }
    }
}
