using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web
{
    public interface IWeatherProvider
    {
        string[] Get();
    }
}
