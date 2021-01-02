using Autofac;
using FluentAssertions;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using System.Collections.Generic;
using Xunit;

namespace PriceGetter.PersistenceEntityFramework.IntegrationTests.ProductsRepositoryTests
{
    public class ProductGettingTests : TestClassWithServiceProvider
    {
        [Fact]
        public void Get_ObtainedCollection_ShouldNotBeNull()
        {
            IProductsRepository productsRepository = this.serviceProvider.Resolve<IProductsRepository>();

            IEnumerable<Product> products = productsRepository.Get().Result;

            products.Should().NotBeNull();
        }
    }
}
