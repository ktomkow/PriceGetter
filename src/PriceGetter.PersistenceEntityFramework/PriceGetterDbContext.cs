using Microsoft.EntityFrameworkCore;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.PersistenceEntityFramework.TypesConfigurations;

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

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(x => x.Id);
            modelBuilder.Entity<Price>().Property(x => x.At);
            modelBuilder.Entity<Price>().OwnsOne(x => x.Amount).Property(x => x.ValuAsDecimal).HasColumnName("Amount");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
