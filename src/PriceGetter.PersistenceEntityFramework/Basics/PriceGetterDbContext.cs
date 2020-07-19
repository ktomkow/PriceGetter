using Microsoft.EntityFrameworkCore;
using PriceGetter.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceEntityFramework.Basics
{
    public class PriceGetterDbContext : DbContext
    {
        private readonly SqlSettings dbSettings;

        public PriceGetterDbContext(SqlSettings dbSettings)
        {
            this.dbSettings = dbSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={this.dbSettings.ConnectionString}");
        }
    }
}
