using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceEntityFramework.TypesConfigurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.At);
            builder.Property(x => x.Amount)
                .HasColumnName("Amount")
                .HasColumnType("decimal(19,4")
                .HasConversion(
                x => x.ValueAsDecimal,
                x => new Money(x));




            //    builder.HasKey(x => x.Id);
            //    builder.HasMany(x => x.Prices);

            //    builder.Property(x => x.ProductPage)
            //        .HasConversion(
            //        x => x.ToStringNullIfEmpty(),
            //        x => Url.FromString(x))
            //        .HasColumnName("PageUrl");

            //    builder.Property(x => x.ProductImage)
            //        .HasConversion(
            //        x => x.ToStringNullIfEmpty(),
            //        x => Url.FromString(x))
            //        .HasColumnName("ImageUrl");

            //    builder.Property(x => x.Name)
            //        .IsRequired()
            //        .HasConversion(
            //        x => x.ToString(),
            //        x => new Name(x));
        }
    }
}
