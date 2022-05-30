using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Minh.Cs40.Models
{
    public class MyDbContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<PersionEntity> persion { get; set; }
        public DbSet<ProductEntity> product { get; set; }
        public DbSet<CategoryEntity> category { get; set; }

        private const string _connectionString = @"
            Data Source=localhost,1433;
            Initial Catalog=dotnet_rearch;
            User ID=SA;
            Password=Nhtminh09032002";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies(); // Tự động load các reference (các trường được sử dụng khóa phụ). Để dùng tính năng phải thêm virtual trước các Property cần tự động
        }
    }
}
