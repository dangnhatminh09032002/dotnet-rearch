using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Linq;
using System.Reflection;

namespace Minh.Cs40
{
    class Persion
    {
        public int id;
        public string name;
        public int age;
    }

    public class Program
    {
        static async Task CreateDatabase()
        {
        }
        public static async Task Main(string[] args)
        {
            string connString = "Host=localhost;Username=postgres;Password=Nhtminh09032002@;Database=dotnet_rearch";
            await using NpgsqlConnection conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            // Retrieve all rows
            await using (var cmd = new NpgsqlCommand("SELECT * FROM persion", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                Persion[] persions = new Persion[12];
                while (await reader.ReadAsync())
                {
                    Persion persion = new Persion();
                    persion.id = Int32.Parse(reader.GetValue(0).ToString());
                    persion.name = reader.GetValue(1).ToString();
                    persion.age = Int32.Parse(reader.GetValue(2).ToString());

                    Console.WriteLine(nameof(persion.id) + ": " + persion.id);
                    Console.WriteLine(nameof(persion.name) + ": " + persion.name);
                    Console.WriteLine(nameof(persion.age) + ": " + persion.age);
                    persions[persion.id] = persion;
                }
            }

        }
    }
}
