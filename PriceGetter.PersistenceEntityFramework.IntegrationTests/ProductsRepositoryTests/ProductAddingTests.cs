using FluentAssertions;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace PriceGetter.PersistenceEntityFramework.IntegrationTests.ProductsRepositoryTests
{
    public class ProductAddingTests : TestClassWithServiceProvider
    {
        [Fact]
        public void Add_IfNoProductsInRepositoryAndAddingNotCommited_CollectionFromRepositoryShouldBeEmpty()
        {
            IUnitOfWork unitOfWork = this.GetUnitOfWork();

            IProductsRepository productsRepository = unitOfWork.ProductRepository;

            Product product = new Product(new Name($"{Guid.NewGuid().ToString().Substring(0,6)}"), Url.FromString(string.Empty));

            productsRepository.Add(product);

            IEnumerable<Product> products = productsRepository.Get().Result;

            products.Should().BeEmpty();
        }
    }
}
