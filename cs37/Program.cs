using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Minh.Cs37
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()); // Cần có Microsoft.Extensions.Configuration.Json để dùng module này;
            configurationBuilder.AddJsonFile("config.json");
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            string connectionString = configurationRoot["Database:PostgreSql:ConnectString:HangfireConnection"];

            //Connect to database
            // SqlConnection connection = new SqlConnection(connectionString);
            // Console.WriteLine(connection.State);
            // connection.Open();
            // Console.WriteLine(connection.State);
            // connection.Close();
        }
    }
}