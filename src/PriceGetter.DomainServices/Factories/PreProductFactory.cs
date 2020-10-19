using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.DomainServices.Factories
{
    public class PreProductFactory : IPreProductFactory
    {
        // TODO: Tu korzystanie z abstrakcji tych obiektów do pobierania danych

        public PreProduct Create(Url imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
