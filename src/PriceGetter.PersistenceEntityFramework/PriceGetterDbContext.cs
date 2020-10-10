using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.PersistenceEntityFramework.TypesConfigurations;

namespace PriceGetter.PersistenceEntityFramework
{
    public class PriceGetterDbContext : DbContext
    {
        private readonly SqlSettings settings;

        public DbSet<Product> Products { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public PriceGetterDbContext()
        {

        }

        public PriceGetterDbContext(SqlSettings sqlSettings)
        {
            this.settings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(this.settings is null)
            {
                optionsBuilder
                .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PriceGetter;Trusted_Connection=True;")
                .UseLoggerFactory(MyLoggerFactory);
            }
            else
            {
                optionsBuilder
                .UseSqlServer(this.settings.ConnectionString)
                .UseLoggerFactory(MyLoggerFactory);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(x => x.Id);
            modelBuilder.Entity<Price>().Property(x => x.At);
            modelBuilder.Entity<Price>().OwnsOne(x => x.Amount)
                .Property(x => x.ValuAsDecimal)
                .HasColumnName("Amount")
                .HasColumnType("decimal(19,4");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
