using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceGetter.PersistenceMongo
{
    public static class Collections
    {
        public static readonly string Products = "Products";
        public static readonly string Sellers = "Sellers";
        public static readonly string ProductFollows = "ProductFollows";

        public static IEnumerable<string> All()
        {
            IEnumerable<string> names =
                typeof(Collections)
                .GetFields()
                .Where(x => x.IsStatic)
                .Where(x => x.IsPublic)
                .Select(x => x.GetValue(null).ToString());

            return names;
        }
    }
}
