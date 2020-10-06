using Microsoft.EntityFrameworkCore;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.PersistenceEntityFramework
{
    public class PriceGetterDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PriceGetterDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PriceGetter;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasMany(x => x.Prices);

            modelBuilder.Entity<Product>().Property(x => x.ProductPage)
                .HasConversion(
                x => x.ToString(),
                x => new Url(x))
                .HasColumnName("PageUrl");

            modelBuilder.Entity<Product>().Property(x => x.ProductImage)
                .HasConversion(
                x => x.ToString(), 
                x => new Url(x))
                .HasColumnName("ImageUrl");

            modelBuilder.Entity<Product>().Property(x => x.Name)
                .IsRequired()
                .HasConversion(
                x => x.ToString(),
                x => new Name(x));

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(x => x.Id);
            modelBuilder.Entity<Price>().Property(x => x.At);
            modelBuilder.Entity<Price>().OwnsOne(x => x.Amount).Property(x => x.ValuAsDecimal).HasColumnName("Amount");
        }
    }
}
