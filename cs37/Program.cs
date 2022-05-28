using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Npgsql;

namespace Minh.Cs37
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Config
            ConfigurationBuilder configarationBuilder = new ConfigurationBuilder();
            configarationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configarationBuilder.AddJsonFile("config.json");

            ConfigurationRoot configRoot = configarationBuilder.Build() as ConfigurationRoot;
            string connectString = configRoot["Database:PostgreSQL:ConnectString:HangfireConnection"];

            // Connect to database
            await using NpgsqlConnection conn = new NpgsqlConnection(connectString);
            await conn.OpenAsync();

            await using NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT * FROM persion", conn);
            await using (NpgsqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    byte buffer = reader.GetByte(0);
                    Console.WriteLine(buffer);
                };
            };
        }
    }
    class Persion
    {
        public int id;
        public string name;
        public int age;
    }
}