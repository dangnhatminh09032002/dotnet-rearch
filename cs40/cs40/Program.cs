using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Minh.Cs40.Models;
using System.Linq;
using Newtonsoft.Json;

//InvertProperty dùng để nói cho khóa ngoại con biết là cần trỏ chính xác đến khóa nào (nếu table đó có nhiều khóa ngoại, nếu k sẽ bị lỗi)

namespace Minh.Cs40
{
    public class Program
    {
        static async Task CreateDatabase()
        {
            using MyDbContext dbcontext = new MyDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            //Console.WriteLine(dbname);

            // statusCreate true if create success
            bool statusCreate = dbcontext.Database.EnsureCreated(); // Kiem tra server có tồn tại database, table được khai báo trong context hay không, nếu không có thì nó sẽ tự động tạo
        }

        static async Task DropDatabase()
        {
            using MyDbContext dbcontext = new MyDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            Console.WriteLine(dbname);

            // statusCreate true if create success
            bool statusDelete = dbcontext.Database.EnsureDeleted();
            if (statusDelete)
            {
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("Create faild");
            }
        }

        static async Task ResetDatabase()
        {
            using MyDbContext dbcontext = new MyDbContext();
            await dbcontext.Database.EnsureDeletedAsync();
            bool statusCreate = await dbcontext.Database.EnsureCreatedAsync();
        }

        static async Task InsertPersion()
        {
            using MyDbContext dbcontext = new MyDbContext();
            object[] obj = new object[]
            {
                new PersionEntity() { Name = "Dang Nhat Minh", Age = 21},
                new PersionEntity() { Name = "Nguyen Dao Nguyen Trinh", Age = 21},
                // new UserEntity..
                // new AccountEntity..
            };

            dbcontext.AddRange(obj);
            int linesChange = dbcontext.SaveChanges(); // trả về sô dòng bị thay đổi bảo gồm thêm sửa xóa
        }

        static async Task ReadPersion()
        {
            using MyDbContext dbContext = new MyDbContext();

            var persions = dbContext.persion.Where(p => p.Id < 10).ToArray();
            persions.ToList().ForEach(p => p.PrintInfo());

            //foreach (PersionEntity persion in persions)
            //{
            //    var json = JsonConvert.SerializeObject(persion);
            //    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            //    Console.WriteLine("_______________");
            //    foreach (KeyValuePair<string, string> kvp in dictionary)
            //    {
            //        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            //    };
            //    Console.WriteLine("_______________");
            //};
        }

        static async Task RenamePersion(int id, string newName)
        {
            using MyDbContext dbcontext = new MyDbContext();
            var p = dbcontext.persion.First(p => p.Id == id);
            p.Name = newName;
            dbcontext.Update(p);
            dbcontext.SaveChanges();
        }

        static async Task RemovePersion(int id)
        {
            using MyDbContext dbcontext = new MyDbContext();
            var p = dbcontext.persion.First(p => p.Id == id);
            dbcontext.persion.Remove(p);
            dbcontext.SaveChanges();
        }

        static async Task InsertProduct()
        {
            using MyDbContext dbcontext = new MyDbContext();

            ProductEntity[] ps = new ProductEntity[]
            {
                new ProductEntity() { Name = "Iphone cua tui", Description = "Iphone moi", Price = 1000, Category = dbcontext.category.First() },
                new ProductEntity() { Name = "Samsung cu tui", Description = "Samsung moi", Price = 2000, Category = dbcontext.category.First() }
            };
            dbcontext.product.AddRange(ps);
            await dbcontext.SaveChangesAsync();
        }

        static async Task ReadProduct() {
            using MyDbContext dbContext = new MyDbContext();

            ProductEntity[] products = dbContext.product.ToArray();
            products.ToList().ForEach(product =>
            {
                Console.WriteLine(product.Category.Name); // Nếu có UseLazyLoadingProxies và thê virtual ở Category thì nó sẽ tự động Reference
                //var e = dbContext.Entry(product);
                //e.Reference(p => p.Category).Load();
                //if (product.Category != null)
                //{
                //    Console.WriteLine(product.Category.Id + " - " + product.Category.Name);
                //}
            });
        }

        static async Task InsertCategory() {
            using MyDbContext dbcontext = new MyDbContext();

            CategoryEntity[] ps = new CategoryEntity[]
            {
                new CategoryEntity() { Name = "Samsung" },
                new CategoryEntity() { Name = "Iphone" }
            };

            dbcontext.category.AddRange(ps);
            await dbcontext.SaveChangesAsync();
        }

        public static async Task Main(string[] args)
        {
            //CreateDatabase();
            //RenamePersion(1, "Dang Nhat Minh");
            //RemovePersion(1);
            //ReadPersion();
            await ResetDatabase();
            await InsertCategory();
            await InsertProduct();
            await ReadProduct();
            //DropDatabase();
        }
    }
}
