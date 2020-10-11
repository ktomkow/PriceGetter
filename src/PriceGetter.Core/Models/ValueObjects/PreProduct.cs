using PriceGetter.Core.BaseClasses.ValueObjects;
using System;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class PreProduct : ValueObjectBase
    {
        public Name Name { get; }

        public Money Price { get; }

        public Url ProductPage { get; }

        public Url ImageUrl { get; }

        public PreProduct(Name name, Money price, Url productPage, Url imageUrl)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price ?? throw new ArgumentNullException(nameof(price));
            ProductPage = productPage ?? throw new ArgumentNullException(nameof(productPage));
            ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
