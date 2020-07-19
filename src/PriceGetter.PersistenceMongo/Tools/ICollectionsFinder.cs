using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.Tools
{
    public interface ICollectionsFinder
    {
        IEnumerable<string> Find();
    }
}
