using PriceGetter.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    interface ITypeProvider
    {
        Type GetType(DataProvider dataProvider); // todo: zwracany byłby typ, a serwis aplikacyjny zawołałby kontener IoC, żeby ten dostarczył odpowiedniego dostawcę cen
    }
}
