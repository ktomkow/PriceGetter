using Autofac;
using FluentAssertions;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Contracts.Products;
using System.Threading.Tasks;
using Xunit;

namespace PriceGetter.SampleServer.Integration.Tests.FromPageExtractTests
{
    public class FromPageXExtractTests : TestClassWithServiceProvider
    {
        private readonly IPreProductService service;

        public FromPageXExtractTests()
        {
            this.service = this.serviceProvider.Resolve<IPreProductService>();
        }

        [Fact]
        public async Task Product1()
        {
            string url = this.samplesServerAddress + "product/1";
            PreProductDto result = await this.service.Get(url);

            result.Should().NotBeNull();
            result.Price.Should().NotBe(default(decimal));
            result.Name.Should().NotBe(default(string));
        }

        [Fact]
        public async Task Product2()
        {
            string url = this.samplesServerAddress + "product/2";
            PreProductDto result = await this.service.Get(url);

            result.Should().NotBeNull();
            result.Price.Should().NotBe(default(decimal));
            result.Name.Should().NotBe(default(string));
        }

        [Fact]
        public async Task Product3()
        {
            string url = this.samplesServerAddress + "product/3";
            PreProductDto result = await this.service.Get(url);

            result.Should().NotBeNull();
            result.Price.Should().NotBe(default(decimal));
            result.Name.Should().NotBe(default(string));
        }
    }
}
