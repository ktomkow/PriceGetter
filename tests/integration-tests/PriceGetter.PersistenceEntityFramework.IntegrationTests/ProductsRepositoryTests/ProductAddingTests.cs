using FluentAssertions;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PriceGetter.PersistenceEntityFramework.IntegrationTests.ProductsRepositoryTests
{
    public class ProductAddingTests : TestClassWithServiceProvider
    {
        [Fact]
        public async Task ActuallyUpdate_AddPriceInSomeStrangeWay()
        {
            IUnitOfWork unitOfWork = this.GetUnitOfWork();
            unitOfWork.OpenTransaction();

            IProductsRepository productsRepository = unitOfWork.ProductRepository;

            Product product = new Product(new Name($"{Guid.NewGuid().ToString().Substring(0, 6)}"), Url.FromString(string.Empty));
            product.AddPrice(new Money(19.99m));

            await productsRepository.Add(product).ConfigureAwait(false);
            await unitOfWork.CommitAsync().ConfigureAwait(false);


            IEnumerable<Product> products = await productsRepository.Get().ConfigureAwait(false);
            var p = products.First();

            productsRepository.Remove(p);
            await unitOfWork.CommitAsync().ConfigureAwait(false);


            p.AddPrice(new Money(39.99m));
            p.AddPrice(new Money(49.99m));
            p.AddPrice(new Money(59.99m));
            p.AddPrice(new Money(69.99m));

            await productsRepository.Add(p);
            await unitOfWork.CommitAsync().ConfigureAwait(false);

            await unitOfWork.RollbackAsync().ConfigureAwait(false);
        }
    }
}
