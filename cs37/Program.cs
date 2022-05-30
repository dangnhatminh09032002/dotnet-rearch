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
            using SqlCommand command = new SqlCommand("SELECT * FROM persion WHERE id < @ID", connection);
            // SqlParameter idParameter = new SqlParameter("@ID", "10");
            // idParameter.Value = 12;
            // command.Parameters.Add(idParameter);

            command.Parameters.AddWithValue("@ID", 10);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) //Check xem có dữ liệu trả về không
                while (reader.Read())
                {
                    Console.WriteLine($"----------\nid: {reader["id"],3}\nname: {reader["name"],10}\nage: {reader["age"],3}");
                }

            connection.Close();
        }
    }
}