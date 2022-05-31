using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Cs43.Domain.Context;
using Cs43.Domain.Entities;
using System.Linq;
using System;

namespace Cs43.Domain.UnitOfWork
{
    public class UnitOfWork
    {
        private static DatabaseContext _databaseContext = new DatabaseContext();
        public static void CreateDatabase() => _databaseContext.Database.EnsureCreated();
        public static void DropDatabase() => _databaseContext.Database.EnsureDeleted();
        public static void InsertCatogory()
        {
            Category[] categorys = new Category[] {
                new Category() { Name = "SmartPhone" },
                new Category() { Name = "Laptop"},
                new Category() { Name = "Monitor"},
                new Category() { Name = "Keyboard"}
            };
            _databaseContext.Categories.AddRange(categorys);
            _databaseContext.SaveChanges();
        }

        public static void InsertProduct()
        {
            Product[] products = new Product[] {
                new Product() { Name = "Dien Thoai", Price = 100, CategoryId = 1 },
                new Product() { Name = "Laptop", Price = 200, CategoryId = 2}
            };
            _databaseContext.Products.AddRange(products);
            _databaseContext.SaveChanges();
        }

        public static void ShowProduct()
        {
            _databaseContext.Products.ToList().ForEach(p => p.ShowInfo());
        }
    }
}
