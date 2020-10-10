﻿using FluentAssertions;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.EntitiesTests.ProductTests
{
    public class ProductCreationTests
    {
        private Name exampleNotEmptyName;

        public ProductCreationTests()
        {
            this.exampleNotEmptyName = new Name("SomeName");
        }

        [Fact]
        public void IdShouldBeGenerated()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void MonitoringActiveFlag_ShouldBeTrue()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.MonitoringActive.Should().BeTrue();
        }

        [Fact]
        public void ProductPage_ShouldNotBeNull()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.ProductPage.Should().NotBeNull();
        }

        [Fact]
        public void ProductPageToString_ShouldBeEmptyString()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.ProductPage.ToString().Should().Be(string.Empty);
        }

        [Fact]
        public void ProductImage_ShouldNotBeNull()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.ProductImage.Should().NotBeNull();
        }

        [Fact]
        public void ProductImageToString_ShouldBeEmptyString()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.ProductImage.ToString().Should().Be(string.Empty);
        }

        [Fact]
        public void Prices_ShouldNotReturnNull()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.Prices.Should().NotBeNull();
        }

        [Fact]
        public void Prices_ShouldReturnEmptyCollection()
        {
            Product product = new Product(this.exampleNotEmptyName);

            product.Prices.Should().BeEmpty();
        }
    }
}
