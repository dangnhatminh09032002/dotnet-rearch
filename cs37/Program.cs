using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

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
            string connectionString = configurationRoot["Database:SqlServer:ConnectString:HangfireConnection"];

            // SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            // sqlConnectionStringBuilder.Add("Server", "localhost");
            // SqlConnectionStringBuilder.Add("Port", "1433");
            // sqlConnectionStringBuilder.Add("Database", "dotnet_rearch");
            // sqlConnectionStringBuilder.Add("UID", "sa");
            // sqlConnectionStringBuilder.Add("PWD", "Nhtminh09032002");
            // connectionString = sqlConnectionStringBuilder.ToString();

            //Connect to database
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //Query the database
            using SqlCommand command = new SqlCommand("SELECT TOP 20 * FROM persion", connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"----------\nid: {reader["id"], 3}\nname: {reader["name"],10}\nage: {reader["age"],3}");
            }

            connection.Close();
        }
    }
}