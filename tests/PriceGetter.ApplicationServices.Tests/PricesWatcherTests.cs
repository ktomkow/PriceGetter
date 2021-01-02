using FluentAssertions;
using NSubstitute;
using PriceGetter.ApplicationServices.ServicesImplementation;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PriceGetter.ApplicationServices.Tests
{
    public class PricesWatcherTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductsRepository productsRepository;
        private readonly ProductFactory productFactory;
        private readonly PricesWatcher watcher;

        public PricesWatcherTests()
        {
            this.unitOfWork = Substitute.For<IUnitOfWork>();
            this.productsRepository = Substitute.For<IProductsRepository>();
            this.productFactory = new ProductFactory();

            this.unitOfWork.ProductRepository.Returns(this.productsRepository);

            this.watcher = new PricesWatcher(unitOfWork);
        }

        [Fact]
        public async Task AnyWorkLeft_IfNoMonitoredProducts_ShouldBeFalse()
        {
            this.productsRepository.GetMonitored().Returns(Task.FromResult(Enumerable.Empty<Product>()));

            bool result = await this.watcher.AnyWorkLeft();

            result.Should().BeFalse();
        }

        [Fact]
        public async Task AnyWorkLeft_IfOnlyMonitoredProductAlreadyCheckedToday_ShouldBeFalse()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            List<Product> productsToBeReturned = new List<Product>();
            Product alreadyCheckedProduct = this.productFactory.Create(new DateTime(2020, 10, 10, 6, 45, 30));
            productsToBeReturned.Add(alreadyCheckedProduct);
            this.productsRepository.GetMonitored().Returns(Task.FromResult(productsToBeReturned as IEnumerable<Product>));

            dateTimeProvider.UtcNow().Returns(new DateTime(2020, 10, 10, 10, 50, 30));
            bool result = await this.watcher.AnyWorkLeft();

            result.Should().BeFalse();
        }

        [Fact]
        public async Task AnyWorkLeft_IfOnlyMonitoredProductNeverCheckeed_ShouldBeTrue()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            List<Product> productsToBeReturned = new List<Product>();
            Product neverCheckedProduct = this.productFactory.Create();
            productsToBeReturned.Add(neverCheckedProduct);
            this.productsRepository.GetMonitored().Returns(Task.FromResult(productsToBeReturned as IEnumerable<Product>));

            dateTimeProvider.UtcNow().Returns(new DateTime(2020, 10, 10, 10, 50, 30));
            bool result = await this.watcher.AnyWorkLeft();

            result.Should().BeTrue();
        }
    }
}
