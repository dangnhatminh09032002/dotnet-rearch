using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Cs42.Domain.Entities;
using Cs42.Domain.EntityTypeConfigarations;

namespace Cs42.Domain.Context
{
    public class DatabaseContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        private const string _connectString = "Data Source=localhost,1433;Initial Catalog=dotnet_rearch;User ID=SA;Password=Nhtminh09032002";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectString);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnConfiguring hoàn thành rồi mới đến phương thức này
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
            //modelBuilder.Entity(typeof(ProductEntity));
            //modelBuilder.Entity<ProductEntity>();
            modelBuilder.Entity<Product>(CategoryEntityTypeConfiguration.Configuration);

        }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
    }
}
