using FluentAssertions;
using NSubstitute;
using PriceGetter.ApplicationServices.ServicesImplementation;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.TestHelpers;
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
        private readonly IDataProviderFactory dataProviderFactory;
        private readonly ProductFactory productFactory;
        private readonly PricesWatcher watcher;

        public PricesWatcherTests()
        {
            this.unitOfWork = Substitute.For<IUnitOfWork>();
            this.productsRepository = Substitute.For<IProductsRepository>();
            this.dataProviderFactory = Substitute.For<IDataProviderFactory>();
            this.productFactory = new ProductFactory();

            this.unitOfWork.ProductRepository.Returns(this.productsRepository);

            this.watcher = new PricesWatcher(this.unitOfWork, this.dataProviderFactory);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public async Task AnyWorkLeft_IfNoMonitoredProducts_ShouldBeFalse()
        {
            this.productsRepository.GetMonitored().Returns(Task.FromResult(Enumerable.Empty<Product>()));

            bool result = await this.watcher.AnyWorkLeft();

            result.Should().BeFalse();
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public async Task AnyWorkLeft_IfTheOnlyMonitoredProductAlreadyCheckedToday_ShouldBeFalse()
        {
            Product alreadyCheckedProduct = this.productFactory.Create(new DateTime(2020, 10, 10, 6, 45, 30));
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            List<Product> productsToBeReturned = new List<Product>();
            productsToBeReturned.Add(alreadyCheckedProduct);
            this.productsRepository.GetMonitored().Returns(Task.FromResult(productsToBeReturned as IEnumerable<Product>));

            dateTimeProvider.UtcNow().Returns(new DateTime(2020, 10, 10, 10, 50, 30));
            bool result = await this.watcher.AnyWorkLeft();

            result.Should().BeFalse();
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public async Task AnyWorkLeft_IfOnlyMonitoredProductNeverCheckeed_ShouldBeTrue()
        {
            Product neverCheckedProduct = this.productFactory.Create();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            List<Product> productsToBeReturned = new List<Product>();
            productsToBeReturned.Add(neverCheckedProduct);
            this.productsRepository.GetMonitored().Returns(Task.FromResult(productsToBeReturned as IEnumerable<Product>));

            dateTimeProvider.UtcNow().Returns(new DateTime(2020, 10, 10, 10, 50, 30));
            bool result = await this.watcher.AnyWorkLeft();

            result.Should().BeTrue();
        }
    }
}
