using NSubstitute;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;

namespace PriceGetter.ApplicationServices.Tests
{
    internal class ProductFactory
    {
        internal Product Create(params DateTime[] pricesAt)
        {
            Product product = new Product(this.RandomName(), this.EmptyUrl());
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            foreach (var datetime in pricesAt)
            {
                dateTimeProvider.UtcNow().Returns(datetime);
                product.AddPrice(this.RandomAmount());
            }

            return product;
        }

        private Name RandomName()
        {
            string randomString = Guid.NewGuid().ToString().Substring(0, 10);
            return new Name(randomString);
        }

        private Url EmptyUrl()
        {
            return Url.FromString(string.Empty);
        }

        private Money RandomAmount()
        {
            return new Money(19.49m);
        }
    }
}
