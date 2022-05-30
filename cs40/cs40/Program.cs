using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Minh.Cs40.Models;
using System.Linq;
using Newtonsoft.Json;

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
            dbcontext.Database.EnsureDeleted();
            bool statusCreate = dbcontext.Database.EnsureCreated();
        }

        static async Task InsertPersion()
        {
            using MyDbContext dbcontext = new MyDbContext();

            //PersionEntity persion1 = new PersionEntity();
            //persion1.Name = "Dang Nhat Minh";
            //persion1.Age = 21;

            //PersionEntity persion2 = new PersionEntity();
            //persion2.Name = "Nguyen Dao Nguyen Trinh";
            //persion2.Age = 22;

            //persionDbContext.Add(persion1);
            //persionDbContext.Add(persion2);


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
                new ProductEntity() { Name = "Iphone", Description = "Iphone moi", Price = 1000 },
                new ProductEntity() { Name = "Samsung", Description = "Samsung moi", Price = 2000 }
            };

            dbcontext.product.AddRange(ps);
            dbcontext.SaveChanges();
        }

        public static async Task Main(string[] args)
        {
            //CreateDatabase();
            //RenamePersion(1, "Dang Nhat Minh");
            //RemovePersion(1);
            //ReadPersion();
            ResetDatabase();
            //InsertProduct();
            //DropDatabase();
        }
    }
}
